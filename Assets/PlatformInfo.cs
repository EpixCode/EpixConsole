using System;
using System.Collections.Generic;
using UnityEngine;
public class PlatformInfo 
{
    //System Info
    public string DeviceModel { get; private set; }
    public string DeviceName { get; private set; }
    public DeviceType DeviceType { get; private set; }
    public string DeviceUniqueIdentifier { get; private set; }
    public int GraphicsDeviceID { get; private set; }
    public string GraphicsDeviceName { get; private set; }
    public string GraphicsDeviceVendor { get; private set; }
    public int GraphicsDeviceVendorID { get; private set; }
    public string GraphicsDeviceVersion { get; private set; }
    public int GraphicsMemorySize { get; private set; }
    public int GraphicsPixelFillrate { get; private set; }
    public int GraphicsShaderLevel { get; private set; }
    public int MaxTextureSize { get; private set; }
    public NPOTSupport NPOTSupport { get; private set; }
    public string OperatingSystem { get; private set; }
    public int ProcessorCount { get; private set; }
    public string ProcessorType { get; private set; }
    public int SupportedRenderTargetCount { get; private set; }
    public bool Supports3DTextures { get; private set; }
    public bool SupportsAccelerometer { get; private set; }
    public bool SupportsComputeShaders { get; private set; }
    public bool SupportsGyroscope { get; private set; }
    public bool SupportsImageEffects { get; private set; }
    public bool SupportsInstancing { get; private set; }
    public bool SupportsLocationService { get; private set; }
    public bool SupportsRenderTextures { get; private set; }
    public bool SupportsRenderToCubemap { get; private set; }
    public bool SupportsShadows { get; private set; }
    public int SupportsStencil { get; private set; }
    public bool SupportsVertexPrograms { get; private set; }
    public bool SupportsVibration { get; private set; }
    public int SystemMemorySize { get; private set; }


    public string Report { get; private set; }
    private List<Info> configList;

    internal class Info
    {
        public Info(string property, string value)
        {
            this.Property = property;
            this.Value = value;
        }

        public string Property { get; private set; }
        public string Value { get; private set; }
    }

    public PlatformInfo()
    {
        Init();
        CreateReport();
    }
	
    private void Init()
    {
        configList = new List<Info>();

        DeviceModel = SystemInfo.deviceModel;
        configList.Add(new Info("Device Model", SystemInfo.deviceModel));
        
        DeviceName = SystemInfo.deviceName;
        configList.Add(new Info("Device Name", SystemInfo.deviceName));

        DeviceType = SystemInfo.deviceType;
        configList.Add(new Info("Device Type", SystemInfo.deviceType.ToString()));

        DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
        configList.Add(new Info("Device Unique ID", SystemInfo.deviceUniqueIdentifier));

        GraphicsDeviceID = SystemInfo.graphicsDeviceID;
        configList.Add(new Info("Graphics Device ID", SystemInfo.graphicsDeviceID.ToString()));

        GraphicsDeviceName = SystemInfo.graphicsDeviceName;
        configList.Add(new Info("Graphics Device Name", SystemInfo.graphicsDeviceName));

        GraphicsDeviceVendor = SystemInfo.graphicsDeviceVendor;
        configList.Add(new Info("Graphics Device Vendor", SystemInfo.graphicsDeviceVendor));

        GraphicsDeviceVendorID = SystemInfo.graphicsDeviceVendorID;
        configList.Add(new Info("Graphics Device Vendor ID", SystemInfo.graphicsDeviceVendorID.ToString()));

        GraphicsDeviceVersion = SystemInfo.graphicsDeviceVersion;
        configList.Add(new Info("Graphics Device Version", SystemInfo.graphicsDeviceVersion));

        GraphicsMemorySize = SystemInfo.graphicsMemorySize;
        configList.Add(new Info("Graphics Memory Size", SystemInfo.graphicsMemorySize.ToString()));

        GraphicsPixelFillrate = SystemInfo.graphicsPixelFillrate;
        configList.Add(new Info("Graphics Device Version", SystemInfo.graphicsDeviceVersion));

        GraphicsShaderLevel = SystemInfo.graphicsShaderLevel;
        configList.Add(new Info("Graphics Shader Level", SystemInfo.graphicsDeviceVersion));

        MaxTextureSize = SystemInfo.maxTextureSize;
        configList.Add(new Info("Max Texture Size", SystemInfo.maxTextureSize.ToString()));

        NPOTSupport = SystemInfo.npotSupport;
        configList.Add(new Info("NPOT Support", SystemInfo.npotSupport.ToString()));

        OperatingSystem = SystemInfo.operatingSystem;
        configList.Add(new Info("Operating System", SystemInfo.operatingSystem));

        ProcessorCount = SystemInfo.processorCount;
        configList.Add(new Info("Processor Count", SystemInfo.processorCount.ToString()));
        
        ProcessorType = SystemInfo.processorType;
        configList.Add(new Info("Processor Type", SystemInfo.processorType));

        SupportedRenderTargetCount = SystemInfo.supportedRenderTargetCount;
        configList.Add(new Info("Supported Render Target Count", SystemInfo.supportedRenderTargetCount.ToString()));

        Supports3DTextures = SystemInfo.supports3DTextures;
        configList.Add(new Info("Supports 3D Textures", SystemInfo.supports3DTextures.ToString()));

        SupportsAccelerometer = SystemInfo.supportsAccelerometer;
        configList.Add(new Info("Supports Accelerometer", SystemInfo.supportsAccelerometer.ToString()));

        SupportsComputeShaders = SystemInfo.supportsComputeShaders;
        configList.Add(new Info("Supports Compute Shaders", SystemInfo.supportsComputeShaders.ToString()));

        SupportsGyroscope = SystemInfo.supportsGyroscope;
        configList.Add(new Info("Supports Gyroscope", SystemInfo.supportsGyroscope.ToString()));

        SupportsImageEffects = SystemInfo.supportsImageEffects;
        configList.Add(new Info("Supports Image Effects", SystemInfo.supportsImageEffects.ToString()));

        SupportsInstancing = SystemInfo.supportsInstancing;
        configList.Add(new Info("Supports Instancing", SystemInfo.supportsInstancing.ToString()));

        SupportsLocationService = SystemInfo.supportsLocationService;
        configList.Add(new Info("Supports Location Service", SystemInfo.supportsLocationService.ToString()));
        
        SupportsRenderTextures = SystemInfo.supportsRenderTextures;
        configList.Add(new Info("Supports Render Textures", SystemInfo.supportsRenderTextures.ToString()));

        SupportsRenderToCubemap = SystemInfo.supportsRenderToCubemap;
        configList.Add(new Info("Supports Render To Cubemap", SystemInfo.supportsRenderToCubemap.ToString()));

        SupportsShadows = SystemInfo.supportsShadows;
        configList.Add(new Info("Supports Shadowa", SystemInfo.supportsShadows.ToString()));

        SupportsStencil = SystemInfo.supportsStencil;
        configList.Add(new Info("Supports Stencil", SystemInfo.supportsStencil.ToString()));
        
        SupportsVertexPrograms = SystemInfo.supportsVertexPrograms;
        configList.Add(new Info("Supports Vertex Programs", SystemInfo.supportsVertexPrograms.ToString()));

        SupportsVibration = SystemInfo.supportsVibration;
        configList.Add(new Info("Supports Vibration", SystemInfo.supportsVibration.ToString()));
        
        SystemMemorySize = SystemInfo.systemMemorySize;
        configList.Add(new Info("System Memory Size", SystemInfo.systemMemorySize.ToString()));
        //...
    }

    private void CreateReport()
    {
        Report = "";;
        Report += "SPECS" + '\n';
        Report += "DeviceModel: " + DeviceModel + '\n';
        Report += "DeviceName: " + DeviceName + '\n';
        Report += "DeviceType: " + DeviceType.ToString() + '\n';
        Report += "DeviceUniqueIdentifier: " + DeviceUniqueIdentifier + '\n';
        Report += "GraphicsDeviceID: " + GraphicsDeviceID + '\n';
        Report += "GraphicsDeviceName: " + GraphicsDeviceName + '\n';
        Report += "GraphicsDeviceVendor: " + GraphicsDeviceVendor + '\n';
        Report += "GraphicsDeviceVendorID: " + GraphicsDeviceVendorID + '\n';
        Report += "GraphicsDeviceVersion: " + GraphicsDeviceVersion + '\n';
        Report += "GraphicsMemorySize: " + GraphicsMemorySize + '\n';
        Report += "GraphicsPixelFillrate: " + GraphicsPixelFillrate + '\n';
        Report += "GraphicsShaderLevel: " + GraphicsShaderLevel + '\n';
        Report += "MaxTextureSize: " + MaxTextureSize + '\n';
        Report += "NPOTSupport: " + NPOTSupport + '\n';
        Report += "OperatingSystem: " + OperatingSystem + '\n';
        Report += "ProcessorCount: " + ProcessorCount + '\n';
        Report += "ProcessorType: " + ProcessorType + '\n';
        Report += '\n';
        Report += "FEATURES" + '\n';
        Report += "SupportedRenderTargetCount: " + SupportedRenderTargetCount + '\n';
        Report += "Supports3DTextures: " + Supports3DTextures.ToString() + '\n';
        Report += "SupportsAccelerometer: " + SupportsAccelerometer.ToString() + '\n';
        Report += "SupportsComputeShaders: " + SupportsComputeShaders.ToString() + '\n';
        Report += "SupportsGyroscope:" + SupportsGyroscope.ToString() + '\n';
        Report += "SupportsImageEffects: " + SupportsImageEffects.ToString() + '\n';
        Report += "SupportsInstancing: " + SupportsInstancing.ToString() + '\n';
        Report += "SupportsLocationService: " + SupportsLocationService.ToString() + '\n';
        Report += "SupportsRenderTextures: " + SupportsRenderTextures.ToString() + '\n';
        Report += "SupportsRenderToCubemap: " + SupportsRenderToCubemap.ToString() + '\n';
        Report += "SupportsShadows: " + SupportsShadows.ToString() + '\n';
        Report += "SupportsStencil: " + Convert.ToBoolean(SupportsStencil).ToString() + '\n';
        Report += "SupportsVertexPrograms: " + SupportsVertexPrograms.ToString() + '\n';
        Report += "SupportsVibration: " + SupportsVibration.ToString() + '\n';
        Report += "SystemMemorySize: " + SystemMemorySize + '\n';
    }
}
