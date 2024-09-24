﻿#nullable disable
namespace ToDoList.Shared.Core;

public class Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get => instance;
        set
        {
            instance = value;
        }
    }
}
