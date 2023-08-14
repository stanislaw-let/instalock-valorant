using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace instalock_valorant
{
    internal class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        static void MoveCursor(int x, int y, CancellationToken cancellationToken)
        {
            SetCursorPos(x, y);
            Thread.Sleep(50);
        }

        static void Click(int x, int y, CancellationToken cancellationToken)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
            Thread.Sleep(50);
        }

        static bool IsKeyPressed(ConsoleKey key)
        {
            int vKey = (int)key;
            return (GetAsyncKeyState(vKey) & 0x8000) != 0;
        }

        static void FileInit()
        {
            string settingsFilePath = "settings.txt";

            if (!File.Exists(settingsFilePath))
            {
                Console.Write("Enter your aspect ratio (e.g. 16:9): ");
                string userRes = Console.ReadLine();

                Console.Write("Enter your res (e.g. 1920x1080): ");
                string userRatio = Console.ReadLine();

                Console.Write("Enter agent name (e.g. Reyna): ");
                string userAgent = Console.ReadLine();

                Console.Write("Enter shortcut: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                string userShortcut = keyInfo.KeyChar.ToString();

                string[] settings = { userRes, userRatio, userAgent, userShortcut };
                File.WriteAllLines(settingsFilePath, settings);
                Console.WriteLine("\nData saved!");
            }
        }

        static void AgentLock()
        {
            Agents agents = new Agents();
            agents.InitializeDictionary();
            string settingsFilePath = "settings.txt";
            string[] settings = File.ReadAllLines(settingsFilePath);
            string userRatio = settings[0];
            string userRes = settings[1];
            string userAgent = settings[2];
            string userShortcut = settings[3];

            if (agents.agentsDictionary.TryGetValue(userAgent, out Agents agent))
            {
                Console.WriteLine("Waiting for shortcut...");
                bool isAgentSelectionRunning = false;
                Thread.Sleep(400);

                ConsoleKey userShortcutKey = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), userShortcut, true);

                while (true)
                {
                    bool isShortcutPressed = IsKeyPressed(userShortcutKey);

                    if (isShortcutPressed)
                    {
                        Console.WriteLine("Shortcut pressed. Starting Agent selection...");
                        isAgentSelectionRunning = true;

                        while (isAgentSelectionRunning)
                        {
                            Thread.Sleep(100);
                            bool isShortcutPressed2 = IsKeyPressed(userShortcutKey);

                            if (isShortcutPressed2)
                            {
                                Console.WriteLine("Shortcut pressed. Stopping Agent selection...");
                                Console.WriteLine("Instalock succsessful!\nClose the app");
                                isAgentSelectionRunning = false;
                                Thread.Sleep(700);
                                break;
                            }

                            else
                            {
                                MoveCursor(agent.X, agent.Y, cancellationTokenSource.Token);
                                Click(agent.X, agent.Y, cancellationTokenSource.Token);
                                Thread.Sleep(10);
                                Lock();
                                Click(agent.X, agent.Y, cancellationTokenSource.Token);
                                Thread.Sleep(10);
                            }
                        }
                    }
                }
            }
        }
        static void AgentSelect()
        {
            Agents agents = new Agents();
            agents.InitializeDictionary();
            string settingsFilePath = "settings.txt";
            string[] settings = File.ReadAllLines(settingsFilePath);

            if (settings.Length == 4)
            {
                string userRatio = settings[0];
                string userRes = settings[1];
                string userAgent = settings[2];
                string userShortcut = settings[3];

                if (userRatio == "16:9")
                    if (userRes == "1920x1080")
                        AgentLock();
            }
        }
        static void Lock()
        {
            MoveCursor(964, 813, cancellationTokenSource.Token);
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
=============================================================
              ___         _        _         _   
             |_ _|_ _  __| |_ __ _| |___  __| |__
              | || ' \(_-<  _/ _` | / _ \/ _| / /
             |___|_||_/__/\__\__,_|_\___/\__|_\_\
             \ \ / /_ _| |___ _ _ __ _ _ _| |_   
              \ V / _` | / _ \ '_/ _` | ' \  _|  
               \_/\__,_|_\___/_| \__,_|_||_\__|  
                                                         v1.0
=============================================================
                   github.com/stanislaw-let
=============================================================");

            Console.WriteLine("Use previous settings?\n" +
                "1. Yes\n" +
                "2. No");
            int userSettingsInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=============================================================");

            if (userSettingsInput == 1)
            {
                AgentSelect();
            }
        }

        static void Main(string[] args)
        {
            Exception exception;
            try
            {
                FileInit();
                ShowMenu();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}