Imports System
Imports System.Net
Imports System.Windows.Forms
Public Class F_Splash

    Private Sub F_Splash_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            If LoadConfigurasuDB() = False Then
                Exit Sub
            Else
                Try
                    F_Login.ShowDialog()

                Catch ex As Exception
                    ex.Message.ToString()
                End Try
            End If
        Catch ex As Exception
            ex.Message.ToString()
        End Try
    End Sub
End Class
