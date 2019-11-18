Imports System
Imports System.Net
Imports Microsoft.Win32
Imports MySql.Data.MySqlClient
Imports System.Security.AccessControl

Public Class F_SettingDatabase

    Private iserver, iuserid, ipassword, idatabase As String

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        regkey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\Application\\koneksi\\db")

        If Not (regkey Is Nothing) Then
            txtIP.Text = regkey.GetValue("server").ToString
            txtUserID.Text = regkey.GetValue("userid").ToString
            txtPassword.Text = regkey.GetValue("password").ToString
            txtDatabase.Text = regkey.GetValue("database").ToString
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BtnKonek_Click(sender As System.Object, e As System.EventArgs) Handles BtnKonek.Click
        If txtIP.Text = String.Empty AndAlso txtUserID.Text = String.Empty AndAlso txtDatabase.Text = String.Empty Then
            MsgBox("lengkapi isi datanya", MsgBoxStyle.Critical)
            Exit Sub
        Else

            If TestConnetion() = True Then
                If CreatedConfigRegistri(txtIP.Text, txtUserID.Text, txtPassword.Text, txtDatabase.Text) = True Then
                    MsgBox("setting database sukses, silakan buka kembali aplikasi anda", MsgBoxStyle.Information)
                    BtnTutup_Click(sender, e)

                Else
                    MsgBox("setting masih gagal", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub BtnTutup_Click(sender As System.Object, e As System.EventArgs) Handles BtnTutup.Click
        Me.Close() : Me.Dispose()
    End Sub

    Private Sub BtnTesKoneksi_Click(sender As System.Object, e As System.EventArgs) Handles BtnTesKoneksi.Click
        If TestConnetion() = True Then
            MsgBox("connecction success", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub F_SettingDatabase_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "l"
    End Sub
End Class