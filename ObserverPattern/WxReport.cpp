using namespace System;

#include "stdafx.h"
#include "WxReport.h"


WxReport::WxReport()
{
	Temperature = -999.9f;
	Wind = gcnew WindData(-999.9f, -999.9f);
}

WxReport::WxReport(String^ location, float temperature, WindData^ wind)
{
	this->Location = location;
	this->Temperature = temperature;
	this->Wind = wind;
}

WindData::WindData()
{
	Speed = -999.9f;
	Direction = -999.9f;
}

WindData::WindData(float speed, float direction)
{
	this->Speed = speed;
	this->Direction = direction;
}

