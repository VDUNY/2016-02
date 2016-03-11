#pragma once

#include "WxReport.h";

/* the nws feed */
ref class WxReporter
{
public:
	delegate void delPublishReport(WxReport^ wxReport);
	event delPublishReport^ evPublishReport;	// this is the tv signal
	static WxReporter^ CreateInstance();
	void OnPublish(WxReport^ wxReport);	/* this is how the feed gets the wx report to interested parties */
private:
	static WxReporter^ Instance;
	WxReporter();


};

