#pragma once

using namespace System;
using namespace System::Threading;

#include "WxReport.h"
#include "WxReporter.h"

/* 
Collects wx data, bundles it up and sends it
out to any subscribed user. 
Does not know who is listening.
*/
ref class WxStation
{
public:
	WxStation(String^ location);
	void Run();
	void Quit();

private:
	WxStation();
	String^ Location;
	float Temperature;
	WindData^ Wind;
	WxReport^ wxReport;	// the data
	WxReporter^ wxReporter;	// the mechanism thru which we inform listeners
	ManualResetEvent^ mreWxStationWaiting;
	Thread^ ThrdRun;
	void IssueWxReports();

};

