using namespace System;

#include "stdafx.h"
#include "TvStation.h"
#include "WxReporter.h"
#include "WxReport.h";

TvStation::TvStation()
{
}

TvStation::TvStation(String^ callsign)
{
	Callsign = callsign;
		// only if we an instance member to not go out of scope
	wxReport = gcnew WxReport("", 0.0f, gcnew WindData(0.0f, 0.0f));
	wxReporter = WxReporter::CreateInstance();

	// this is what tells the nws that there is someone who cares about the wx reports
	wxReporter->evPublishReport += gcnew WxReporter::delPublishReport(this, &TvStation::OnevReceiveReport);

}

void TvStation::Run()
{
	mreTvStationWaiting = gcnew ManualResetEvent(false);
	ThrdRun = gcnew Thread(gcnew ThreadStart(this, &TvStation::ReceiveWxReports));
	ThrdRun->Name = "thrdIssueWxReports";
	ThrdRun->Start();
}

void TvStation::Quit()
{
	mreTvStationWaiting->Set();
	ThrdRun->Join();
}


void TvStation::ReceiveWxReports()
{
	while (!mreTvStationWaiting->WaitOne(3000))
	{
		Console::WriteLine("  " + Callsign + " waiting for wx update. \r\n");
	}
}

/*
when this event is sunk, the tv station has a wx report to tell you
*/
void TvStation::OnevReceiveReport(WxReport^ wxReport)
{
	Console::WriteLine("Tv Sta Callsign: {0}\r\n " +
		wxReport->Location + " reports: "  +
		"Temp (F): {2} (F)/ Wind Spd: {3} mph / "
	+ " Wind Dir: {4} deg \r\n",
	Callsign,
	wxReport->Location,
	wxReport->Temperature.ToString("00.0"),
	wxReport->Wind->Speed.ToString("00.0"),
	wxReport->Wind->Direction.ToString("00.0"));

	this->wxReport = wxReport;
}

