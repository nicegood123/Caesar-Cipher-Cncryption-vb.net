Public Class formLogin

    Public user_id = ""
    Private Sub formLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setConnection("it16l_lab_exam")
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim query = "SELECT id, username, password FROM user WHERE username = '" & txtUsername.Text & "' AND password = '" & cipherEncryption(txtPassword.Text, True) & "' "
        user_id = FindData(query)

        If isFound(query) Then
            txtUsername.Clear()
            txtPassword.Clear()

            Me.Hide()
            formUserProfile.Show()
        Else
            MsgBox("Username/password incorrect.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub lblRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblRegister.LinkClicked
        Me.Hide()
        formRegistration.Show()
    End Sub
End Class
