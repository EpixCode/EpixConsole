using System.Collections.Generic;
using UnityEngine;

public class ELogType
{
    private static List<ELogType> instanceList = new List<ELogType>();
    private static Dictionary<LogType, ELogType> typeRelationDict = new Dictionary<LogType, ELogType>();

    public LogType UnityType { get; private set; }
    public Color Color { get; private set; }
    
    public static readonly ELogType LOG = new ELogType(LogType.Log, Color.white);
    public static readonly ELogType WARNING = new ELogType(LogType.Warning, Color.yellow);
    public static readonly ELogType ERROR = new ELogType(LogType.Error, Color.red);
    public static readonly ELogType EXCEPTION = new ELogType(LogType.Exception, Color.magenta);
    public static readonly ELogType ASSERT = new ELogType(LogType.Assert, Color.cyan);

    public ELogType(LogType unityType, Color color)
    {
        this.UnityType = unityType;
        this.Color = color;

        instanceList.Add(this);
        typeRelationDict.Add(this.UnityType, this);
    }

    public static ELogType GetLogType(LogType unityType)
    {
        return typeRelationDict[unityType];
    }

    public static List<ELogType> GetList()
    {
        return instanceList;
    }
}
