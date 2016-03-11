// ObserverPattern.cpp : main project file.

using namespace System;
using namespace System::Threading;

#include "stdafx.h"
#include "WxReport.h"
#include "WxStation.h"
#include "TvStation.h"

int main(array<System::String ^> ^args)
{
    Console::WriteLine(L"Hello World");

	WxStation^ wxStation = gcnew WxStation("Syracuse");
	wxStation->Run();
	
	TvStation^ tvStation = gcnew TvStation("WHAM");
	tvStation->Run();

	Console::WriteLine(L"<enter> to quit");
	Console::ReadLine();

	wxStation->Quit();
	tvStation->Quit();
    return 0;
}
