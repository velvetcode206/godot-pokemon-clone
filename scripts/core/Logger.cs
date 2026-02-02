using Godot;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace GodotPokemonClone.scripts.core;

public static class Logger
{
	private enum LogLevel
	{
		Debug,
		Info,
		Warning,
		Error
	}

	private static readonly string[] LevelColors =
	[
		"WHITE", // Debug
		"CYAN", // Info
		"YELLOW", // Warning
		"RED" // Error
	];

	private static void Log(
		LogLevel level,
		string message,
		string memberName,
		string filePath,
		int lineNumber
	)
	{
		var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		var className = Path.GetFileNameWithoutExtension(filePath);
		var logColor = LevelColors[(int)level];
		var logText =
			$"[{timestamp}] [{level}] [{className}] [{memberName}:{lineNumber}]";

		GD.PrintRich($"[color={logColor}]{logText}[/color] {message}");
	}

	public static void Debug(
		string message,
		[CallerMemberName] string memberName = "",
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0
	)
		=> Log(LogLevel.Debug, message, memberName, filePath, lineNumber);

	public static void Info(
		string message,
		[CallerMemberName] string memberName = "",
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0
	)
		=> Log(LogLevel.Info, message, memberName, filePath, lineNumber);

	public static void Warning(
		string message,
		[CallerMemberName] string memberName = "",
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0
	)
		=> Log(LogLevel.Warning, message, memberName, filePath, lineNumber);

	public static void Error(
		string message,
		[CallerMemberName] string memberName = "",
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0
	)
		=> Log(LogLevel.Error, message, memberName, filePath, lineNumber);
}
