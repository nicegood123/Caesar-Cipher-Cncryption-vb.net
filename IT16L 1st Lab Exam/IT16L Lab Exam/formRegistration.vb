Public Class formRegistration
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        formLogin.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        formLogin.Show()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim query, password As String

        If txtName.Text = "" Then
            MsgBox("Name field is required.", MsgBoxStyle.Exclamation)
            txtName.Focus()
        ElseIf txtUsername.Text = "" Then
            MsgBox("Username field is required.", MsgBoxStyle.Exclamation)
            txtUsername.Focus()
        ElseIf txtPassword.Text = "" Then
            MsgBox("Password field is required.", MsgBoxStyle.Exclamation)
            txtPassword.Focus()
        Else
            Try

                query = "INSERT INTO user (name, username, password) values('" & txtName.Text.ToLower() & "', '" & txtUsername.Text & "', '" & cipherEncryption(txtPassword.Text, True) & "')"
                SQLProcess(query)
                MsgBox("User successfully added.", MsgBoxStyle.Information)
                Me.Close()
                formLogin.Show()

            Catch ex As Exception
                MsgBox("Registration failed!", MsgBoxStyle.Information)
            End Try


        End If
    End Sub
End Class