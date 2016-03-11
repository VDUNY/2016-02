#include "stdafx.h"
#include "WxReporter.h"


WxReporter::WxReporter()
{
}

/* there can only be one instance of the feed */
WxReporter^ WxReporter::CreateInstance()
{
	if (Instance == nullptr)
	{
		Instance = gcnew WxReporter();
	}
	return Instance;

}

/* the feed has a new wx report to issue */
void WxReporter::OnPublish(WxReport^ wxReport)
{
	// Interestingly, in C# this would throw a null exception if no one listening.
	// C++/cli just steps over the statement w/o exception
	evPublishReport(wxReport);
}
