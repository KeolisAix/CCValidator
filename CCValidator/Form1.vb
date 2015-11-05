Public Class Form1


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' VARIABLES DE DEFINITION A ADAPTER
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim Aujourdhui As DateTime = Date.Now.AddDays(-1)
    Dim Jour As String = Aujourdhui.ToString("dd")
    Dim Mois As String = Aujourdhui.ToString("MM")
    Dim Annee As String = Aujourdhui.ToString("yyyy")
    Dim FICHIER_EVENEMENT_D1 As String = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement.txt"
    Dim FICHIER_EVENEMENT_D1D2 As String = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement_D1D2.txt"
    Dim JourGlobal As String
    Dim MoisGlobal As String
    Public FICHIER_VIDAGE_ORIGNE As String = "C:\COMPTAGE\EVENEMENTS\VIDAGE_BUS.csv"
    Public FICHIER_VIDAGE_FINAL As String = "C:\COMPTAGE\EVENEMENTS\CONTROLE\VIDAGE_CC_FINAL.csv"
    Public FICHIER_BUS As String = "C:\COMPTAGE\EVENEMENTS\CONTROLE\Bus.txt"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(FICHIER_EVENEMENT_D1D2.ToString) Then
            My.Computer.FileSystem.DeleteFile(FICHIER_EVENEMENT_D1D2.ToString)
        End If
        'MsgBox(Aujourdhui.ToString("dd/MM/yyyy"))
        'MsgBox("/K CD C:\COMPTAGE\EVENEMENTS\ & TYPE " + FICHIER_EVENEMENT_D1 + " >> " + FICHIER_EVENEMENT_D1D2 + " & Exit")

        Process.Start("CMD.exe", "/K CD C:\COMPTAGE\EVENEMENTS\ & TYPE " + FICHIER_EVENEMENT_D1 + " >> " + FICHIER_EVENEMENT_D1D2 + " & Exit")
        LireEvenement(FICHIER_EVENEMENT_D1D2, "le PC a reçu l'ACK de mémoire effacée du bus ") ' + ECRIRE_BUS
        AjouterValeur(FICHIER_BUS, FICHIER_VIDAGE_FINAL)
        Process.Start("CMD.exe", "/K move " + FICHIER_EVENEMENT_D1D2 + " C:\COMPTAGE\EVENEMENTS\CONTROLE\ & Exit")
        ExportToCSV(FICHIER_VIDAGE_FINAL)
    End Sub
End Class
