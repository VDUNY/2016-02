#pragma once

using namespace System;
using namespace System::Threading;

#include "WxReport.h";
#include "WxReporter.h";

/* they want to tell you the weather, but the wx station has to give them the wx report */
ref class TvStation
{
public:
	TvStation(String^ callsign);
	void Run();
	void Quit();

private:
	TvStation();
	String^ Callsign;
	WxReport^ wxReport;
	WxReporter^ wxReporter;	// can break this reference with PRISM or WCF or ICE
	ManualResetEvent^ mreTvStationWaiting;
	Thread^ ThrdRun;
	void ReceiveWxReports();	// listen to the nws feed
	void OnevReceiveReport(WxReport^ wxReport);	// paying attention

};

