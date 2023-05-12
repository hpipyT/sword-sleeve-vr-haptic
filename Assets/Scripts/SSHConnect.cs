using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Renci.SshNet;
using TMPro;
using System.Threading.Tasks;
using System.IO;
using System.Net.Security;
using System.Runtime.InteropServices.ComTypes;
using System;
using UnityEditor.PackageManager;

// note script name is SSH-connect
public class SSHConnect : MonoBehaviour
{
    private string text = null;

    private string _host = "192.168.1.142";
    private string _username = "pi";
    private string _password = "vrsword";
    // Start is called before the first frame update
    SshCommand sc;
    Renci.SshNet.SshClient client = null;
    Renci.SshNet.SshCommand command = null;

    public string servoOption;

    void Start()
    {
        StartCoroutine(StartUpRoutine());
    }

    IEnumerator StartUpRoutine()
    {
        ConnectToPi();
        CreateIOStream();
        InitializeTens();
        yield return new WaitForSeconds(1.0f);
        PrepareServoOptions();
        yield return null;
    }


    void ConnectToPi()
    {
        try
        {
            var connectionInfo = new PasswordConnectionInfo(_host, 22, _username, _password);
            text += "connection infos : ok\n";

            client = new SshClient(connectionInfo);

            text += "Connecting...\n";
            client.Connect();
            text += "OK\n";
            print(text);
            text = null;

        }
        catch (System.Exception e)
        {
            text = "Error\n" + e;
            Debug.Log(text + e);

        }
    }



    ShellStream stream;
    public async void CreateIOStream()
    {

        Debug.Log("Creating shellstream...");

        stream = client.CreateShellStream("", 80, 40, 80, 40, 1024);
        Debug.Log("Shellstream created");
        //await Task.Run(() => stream.WriteLine("echo 'sample command output'"));

        await Task.Run(() => stream.WriteLine("1"));

    }

    public async void InitializeTens()
    {
        await Task.Run(() => stream.WriteLine("python3 digipot.py"));
    }

    public async void PrepareServoOptions()
    {
        await Task.Run(() => stream.WriteLine("python3 ServoOptions.py"));
    }

    public async void LaunchServoOption(string option)
    {
        await Task.Run(() => stream.WriteLine(option));

        // Read with a suitable timeout to avoid hanging
/*        string line;
        while ((line = stream.ReadLine(TimeSpan.FromSeconds(2))) != null)
        {
            Console.WriteLine(line);
            Debug.Log(line);

        }*/
        await Task.Run(() => stream.WriteLine("python3 ServoOptions.py"));
    }



    public async void HaltJitter()
    {
        // var command = await Task.Run(() => client.RunCommand("pkill -f JitterServo.py"));
        await Task.Run(() => stream.WriteLine("\u0003"));
        print(command.Result);
    }


    void OnApplicationQuit()
    {
        DisconnectFromPi();
    }

    public void DisconnectFromPi()
    {
        if (client != null)
        {
            text += "Disconnecting...\n";
            client.Disconnect();
            text += "OK\n";
        }

        Debug.Log(text);
    }
}






/*                    var command = client.RunCommand("pwd");
                    text += command.Result;

                    SshCommand sc = client.CreateCommand("cat readme");
                    sc.Execute();
                    text += sc.Result;

                    sc = client.CreateCommand("ping localhost -c 1"); // ping averages between 0.2 and 0.4 ms
                    sc.Execute();
                    text += sc.Result;*/



/*            sc = client.CreateCommand("ping localhost -c 1"); // ping averages between 0.2 and 0.4 ms
            sc.Execute();
            text += sc.Result;*/



/*            sc = client.CreateCommand("ping localhost -c 1"); // ping averages between 0.2 and 0.4 ms
            sc.Execute();
            text += sc.Result;*/

/*public async void RenciTest()
{

    var input = new Renci.SshNet.Common.PipeStream();
    var streamWriter = new StreamWriter(input) { AutoFlush = true };

    var stdout = Console.OpenStandardOutput();
    var shell = client.CreateShell(input, stdout, new Renci.SshNet.Common.PipeStream());
    shell.Start();

    streamWriter.WriteLine("ls");

    string line;
    *//*        while ((line = shell.ReadLine(TimeSpan.FromSeconds(2))) != null)
            {
                Console.WriteLine(line);
                Debug.Log(line);
                // if a termination pattern is known, check it here and break to exit immediately
            }*//*
}*/

// command = await Task.Run(() => client.RunCommand("python3 ServoOptions.py"));
// command = await Task.Run(() => client.RunCommand("python3 Test.py"));