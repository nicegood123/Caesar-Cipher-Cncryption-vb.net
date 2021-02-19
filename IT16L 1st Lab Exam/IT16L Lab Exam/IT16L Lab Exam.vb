Imports System.IO
Imports MySql.Data.MySqlClient

    Module IT16L_Lab_Exam
        Private connection As MySqlConnection
        Private SQLCommand As MySqlCommand
        Private DataAdapter As MySqlDataAdapter
        Private DataTable As DataTable

    Public Sub setConnection(database)
        Try
            Dim db_connection = "server=localhost; user id=root; database="
            connection = New MySqlConnection(db_connection & database)
            connection.Open()

        Catch e As Exception
            ErrorMessage("Error 101: setConnection " & e.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Public Sub SQLProcess(sql)
        Try
            connection.Open()
            SQLCommand = New MySqlCommand(sql, connection)
            With SQLCommand
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            ErrorMessage("Error 104: SQLProcess " & ex.Message)
        Finally
            connection.Close()
        End Try

    End Sub

    Public Function FindData(sql)
        Dim value = 0
        Dim DataReader As MySqlDataReader

        Try
            connection.Open()
            SQLCommand = New MySqlCommand(sql, connection)

            DataReader = SQLCommand.ExecuteReader()

            If DataReader.Read() = True Then
                value = DataReader.GetValue(0)
            End If
            DataReader.Close()
        Catch ex As Exception
            ErrorMessage("Error 106: FindData " & ex.Message)
        Finally
            connection.Close()
        End Try
        Return value
    End Function

    Public Function FindData(sql, column)
        Dim value = ""
        Dim DataReader As MySqlDataReader

        Try
            connection.Open()
            SQLCommand = New MySqlCommand(sql, connection)

            DataReader = SQLCommand.ExecuteReader()

            If DataReader.Read() Then
                value = DataReader.GetString(column)
            End If
            DataReader.Close()
        Catch ex As Exception
            ErrorMessage("Error 107: FindData " & ex.Message)
        Finally
            connection.Close()
        End Try
        Return value
    End Function

    Public Function isFound(sql) As Boolean
        Dim found = False
        Dim DataReader As MySqlDataReader

        Try
            connection.Open()
            SQLCommand = New MySqlCommand(sql, connection)
            DataReader = SQLCommand.ExecuteReader()
            If DataReader.Read() Then
                found = True
            End If
            DataReader.Close()
        Catch ex As Exception
            ErrorMessage("Error 108: isFound " & ex.Message)
        Finally
            connection.Close()
        End Try
        Return found
    End Function

    Public Function cipherEncryption(ByVal password As String, ByVal isEncrypt As Boolean)
        Dim result As String

        For Each character As Char In password
            Dim x As Integer

            If isEncrypt Then
                x = Asc(character) + 3
            Else
                x = Asc(character) + 26 - 3
            End If

            If Char.IsLower(character) Then
                If x > Asc("z") Then
                    x -= 26
                End If
                result += Chr(x)
            ElseIf Char.IsUpper(character) Then
                If x > Asc("Z") Then
                    x -= 26
                End If
                result += Chr(x)
            Else
                result += character
            End If
        Next

        Return result
    End Function

    Public Sub ErrorMessage(message)
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

    End Module

