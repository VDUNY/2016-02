using namespace System;

#include "stdafx.h"
#include "WxStation.h"


WxStation::WxStation()
{
}

WxStation::WxStation(String^ location)
{
	Location = location;
	wxReporter = WxReporter::CreateInstance();	// our weather disseminator
}

void WxStation::Run()
{
	mreWxStationWaiting = gcnew ManualResetEvent(false);
	ThrdRun = gcnew Thread(gcnew ThreadStart(this, &WxStation::IssueWxReports));
	ThrdRun->Name = "thrdIssueWxReports";
	ThrdRun->Start();
}

void WxStation::Quit()
{
	mreWxStationWaiting->Set();
	ThrdRun->Join();
}

/* collecting the data and bundling */
void WxStation::IssueWxReports()
{
	Random^ r = gcnew Random();
	while (!mreWxStationWaiting->WaitOne(8000))
	{
		Temperature = (float)(r->NextDouble());
		Wind = gcnew WindData((float)(r->NextDouble()), (float)(r->NextDouble()));
		WxReport^ wxReport = gcnew WxReport(Location, Temperature, Wind);
		Console::WriteLine("Sta Location: {0}\r\n " +
			"Temperature: {1} (F)/ Wind Spd: {2} mph / "
			+ " Wind Dir: {3} degrees \r\n",
			wxReport->Location,
			wxReport->Temperature.ToString("00.0"),
			wxReport->Wind->Speed.ToString("00.0"),
			wxReport->Wind->Direction.ToString("00.0"));
		// our weather station puts the report on the nws feed
		wxReporter->OnPublish(wxReport);	// c# reqs a null check
	}
}
