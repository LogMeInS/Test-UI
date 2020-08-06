Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports Client

Public Class Form1
    Dim LogMeIn As LogMeIn

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim LoginSettings As New LogMeIn.Settings
        LoginSettings.ServerIp = "127.0.0.1"
        LoginSettings.ServerPort = 3000
        LoginSettings.Paths = New Dictionary(Of String, String)
        LoginSettings.Paths.Add("desktop", "C:\Users\Sereja\Desktop")

        LogMeIn = New LogMeIn(LoginSettings)

        Label6.Text = LogMeIn.GetName()
        IO.File.WriteAllBytes(IO.Path.GetTempPath() + "LoginServelLogo.png", LogMeIn.GetPicture())
        PictureBox1.Image = Image.FromFile(IO.Path.GetTempPath() + "LoginServelLogo.png")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LogMeIn.Login(TextBox1.Text, TextBox2.Text) Then
            MsgBox("Logged In")
        Else
            MsgBox("Fail")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LogMeIn.Register(TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text)
    End Sub
End Class