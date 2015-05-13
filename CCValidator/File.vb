Imports System.IO
Imports System.Text
Module File
    Public Function LireEvenement(ByRef Fichier, ByRef TexteAChercher)
        System.Threading.Thread.Sleep(1000)
        Dim lines() As String
        lines = System.IO.File.ReadAllLines(Fichier.ToString, Encoding.UTF7)
        Dim bus As String
        Dim value As String
        For Each line As String In lines
            If line.Contains(TexteAChercher.ToString) Then
                value = line
                bus = Split(value, "bus ", 2).GetValue(1)
                Form1.Label1.Text = Form1.Label1.Text + 1
                Form1.TextBox1.Text = Form1.TextBox1.Text + bus + Environment.NewLine
            End If
        Next
        Ecrire_BUS(Form1.FICHIER_BUS, Form1.TextBox1.Text)
    End Function
    Public Function Ecrire_BUS(ByRef Fichier, ByRef Texte)
        System.Threading.Thread.Sleep(1000)
        If My.Computer.FileSystem.FileExists(Fichier.ToString) Then
            My.Computer.FileSystem.DeleteFile(Fichier.ToString)
        End If
        'MsgBox(Fichier.ToString)
        'MsgBox(Texte.ToString)
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(Fichier.ToString)
        objStreamWriter.WriteLine(Texte)
        objStreamWriter.Close()
        'MsgBox("Ecrire - BUS - OK")
    End Function
    Public Function AjouterValeur(ByRef BUS, ByRef VIDAGE)
        System.Threading.Thread.Sleep(1000)
        Dim Aujourdhui As DateTime = Date.Now.AddDays(-1)
        Try
            For Each line As String In System.IO.File.ReadAllLines(VIDAGE.ToString)
                Dim word = line.Split(";")
                Form1.DataGridView1.Rows.Add(word(0), word(1), word(2))
            Next
        Catch ex As Exception
            MsgBox("Pb ajout au tableau : " + ex.ToString)
        End Try
        Try
            For Each ligne As String In System.IO.File.ReadAllLines(BUS.ToString)
                For Each row As DataGridViewRow In Form1.DataGridView1.Rows
                    If row.Cells(0).Value = ligne.ToString And row.Cells(0).Value <> "0" Then
                        row.Cells(1).Value = Aujourdhui.ToString("dd/MM/yyyy")
                        row.Cells(2).Value = "0"
                    End If
                Next
            Next
        Catch ex2 As Exception
            MsgBox("Pb Ajout Date: " + ex2.ToString)
        End Try
        'MsgBox("Ajouter - DATAGRID - OK")
    End Function
    Public Function ExportToCSV(ByRef FichierExport)
        ' MsgBox("DEBUT EXPORT - OK")
        Dim StrExport As String = ""
        StrExport = StrExport.Substring(0, StrExport.Length)
        For Each R As DataGridViewRow In Form1.DataGridView1.Rows
            For Each C As DataGridViewCell In R.Cells
                If Not C.Value Is Nothing Then
                    StrExport &= "" & C.Value.ToString & ";"
                Else
                    StrExport &= "" & "" & ";"
                End If
            Next
            StrExport = StrExport.Substring(0, StrExport.Length - 1)
            StrExport &= Environment.NewLine
        Next
        Dim tw As IO.TextWriter = New IO.StreamWriter(FichierExport.ToString)
        tw.Write(StrExport)
        tw.Close()
        'MsgBox("FIN EXPORT - OK")
        Form1.Close()
    End Function
End Module
