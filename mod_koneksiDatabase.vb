Imports System
Imports System.Net
Imports Microsoft.Win32
Imports MySql.Data.MySqlClient

Module mod_koneksiDatabase

    Public regkey As RegistryKey
    Public connectionString As String = Nothing
    Public connectionDB As MySqlConnection
    Public connectionDBTest As MySqlConnection

    Public Function CreatedConfigRegistri(ByRef server As String, ByRef userid As String, ByRef password As String, ByRef database As String) As Boolean

        '// membuat folder di registri windows dengan nama koneksi-db

        regkey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\Application\\koneksi\\db")

        Try
            If Not (regkey Is Nothing) Then
                regkey.SetValue("server", server)
                regkey.SetValue("userid", userid)
                regkey.SetValue("password", password)
                regkey.SetValue("database", database)
            End If

            regkey.Close()
            Return True

        Catch ex As Exception
            ex.Message.ToString()
            Return False
        End Try
    End Function

    Public Function LoadConfigurasuDB() As Boolean

        regkey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\Application\\koneksi\\db")

        If Not (regkey Is Nothing) Then
            connectionString = "server=" + regkey.GetValue("server").ToString +
                                ";userid=" + regkey.GetValue("userid").ToString +
                                ";password=" + regkey.GetValue("password").ToString +
                                ";database=" + regkey.GetValue("database").ToString + ""
        End If

        connectionDB = New MySqlConnection(connectionString)

        Try

            If connectionDB.State = ConnectionState.Closed Then
                connectionDB.Open()
            End If

            Return True
        Catch ex As Exception
            F_Splash.Hide()

            MsgBox("Database tidak ditemuakan", MsgBoxStyle.Critical)

            F_SettingDatabase.ShowDialog()

            Return False
        End Try

    End Function

    Public Function TestConnetion() As Boolean

        connectionString = "server=" + F_SettingDatabase.txtIP.Text +
                          ";userid=" + F_SettingDatabase.txtUserID.Text +
                          ";password=" + F_SettingDatabase.txtPassword.Text +
                          ";database=" + F_SettingDatabase.txtDatabase.Text + ""

        connectionDB = New MySqlConnection(connectionString)

        Try

            If connectionDB.State = ConnectionState.Closed Then
                connectionDB.Open()
            End If

            Return True
        Catch ex As Exception
            MsgBox("Database tidak ditemuakan", MsgBoxStyle.Critical)
            Return False
        End Try

    End Function
End Module
