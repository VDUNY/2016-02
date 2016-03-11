#pragma once

using namespace System;

ref class WindData;	// forward declaration
ref class WxReport;

/* our weather of interest */
public ref class WxReport
{
public:
	WxReport(String^ location, float temperature, WindData^ wind);
	String^ Location;
	float Temperature;
	WindData ^ Wind = nullptr;

private:
	WxReport();

};

ref class WindData
{
public:
	WindData();
	WindData(float speed, float direction);

	float Speed;
	float Direction;

};

