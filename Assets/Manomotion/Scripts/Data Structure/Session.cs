using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AddOn
{
	DEFAULT = 0,
	AR_KIT = 1,
	AR_CORE = 2,
	VUFORIA = 3,
	ARFoundation = 4
};

//Replace this with DeviceOrientation
/// <summary>
/// Provides information regarding the different orientation types supported by the SDK.
/// </summary>
public enum SupportedOrientation
{
	LANDSCAPE_LEFT = 3,
	LANDSCAPE_RIGHT = 4,
	PORTRAIT = 1,
	PORTRAIT_INVERTED = 2
};

/// <summary>
/// Provides additional information regarding the lincenses taking place in this application.
/// </summary>
public enum Flags
{
	FLAG_IMAGE_SIZE_IS_ZERO = 1000,
	FLAG_IMAGE_IS_TOO_SMALL = 1001
};

/// <summary>
/// The session used.
/// </summary>
public struct Session
{
	public Flags flag;
	public DeviceOrientation orientation;
	public AddOn add_on;
	public float smoothing_controller;
	public Features enabled_features;
	public Hand hand;
}

/// <summary>
/// 1 for using it and 0 for not using it.
/// </summary>
public struct Features
{ 
	public int pinch_poi;
};