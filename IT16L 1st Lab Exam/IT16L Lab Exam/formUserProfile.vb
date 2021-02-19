Public Class formUserProfile

    Private Sub formUserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query = "SELECT * FROM user WHERE id = " & formLogin.user_id & " "
        txtName.Text = FindData(query, "name")
        txtUsername.Text = FindData(query, "username")
        txtPassword.Text = FindData(query, "password")
        txtDecryptedPassword.Text = cipherEncryption(txtPassword.Text, False)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        formLogin.Show()
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub
End Class