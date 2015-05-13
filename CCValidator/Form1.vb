Public Class Form1


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' VARIABLES DE DEFINITION A ADAPTER
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim Aujourdhui As DateTime = Date.Now.AddDays(-1)
    Dim Jour As String = Aujourdhui.ToString("dd")
    Dim Mois As String = Aujourdhui.ToString("MM")
    Dim Annee As String = Aujourdhui.ToString("yyyy")
    Dim FICHIER_EVENEMENT_D1 As String = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement.txt"
    Dim FICHIER_EVENEMENT_D2 As String = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement_D2.txt"
    Dim FICHIER_EVENEMENT_D1D2 As String = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement_D1D2.txt"
    Dim JourGlobal As String
    Dim MoisGlobal As String
    Public FICHIER_VIDAGE_ORIGNE As String = "C:\COMPTAGE\EVENEMENTS\VIDAGE_BUS.csv"
    Public FICHIER_VIDAGE_FINAL As String = "C:\COMPTAGE\EVENEMENTS\CONTROLE\VIDAGE_CC_FINAL.csv"
    Public FICHIER_BUS As String = "C:\COMPTAGE\EVENEMENTS\CONTROLE\Bus.txt"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Jour.ToString <= 10 And Mois.Contains("0") = False Then
            'MsgBox(Jour.Substring(1, 1))
            JourGlobal = Jour.Substring(1, 1)
            FICHIER_EVENEMENT_D1 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + JourGlobal + "_Evenement.txt"
            FICHIER_EVENEMENT_D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + JourGlobal + "_Evenement_D2.txt"
            FICHIER_EVENEMENT_D1D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + JourGlobal + "_Evenement_D1D2.txt"
        End If
        If Jour.ToString <= 10 And Mois.Contains("0") = True Then
            JourGlobal = Jour.Substring(1, 1)
            MoisGlobal = Mois.Substring(1, 1)
            FICHIER_EVENEMENT_D1 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + MoisGlobal + "_" + JourGlobal + "_Evenement.txt"
            FICHIER_EVENEMENT_D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + MoisGlobal + "_" + JourGlobal + "_Evenement_D2.txt"
            FICHIER_EVENEMENT_D1D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + MoisGlobal + "_" + JourGlobal + "_Evenement_D1D2.txt"
        End If
        If Jour.ToString >= 10 And Mois.Contains("0") = True Then
            JourGlobal = Jour.Substring(1, 1)
            MoisGlobal = Mois.Substring(1, 1)
            FICHIER_EVENEMENT_D1 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + MoisGlobal + "_" + Jour + "_Evenement.txt"
            FICHIER_EVENEMENT_D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + MoisGlobal + "_" + Jour + "_Evenement_D2.txt"
            FICHIER_EVENEMENT_D1D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + MoisGlobal + "_" + Jour + "_Evenement_D1D2.txt"
        End If
        If Jour.ToString >= 10 And Mois.Contains("0") = False Then
            JourGlobal = Jour.Substring(1, 1)
            MoisGlobal = Mois.Substring(1, 1)
            FICHIER_EVENEMENT_D1 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement.txt"
            FICHIER_EVENEMENT_D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement_D2.txt"
            FICHIER_EVENEMENT_D1D2 = "C:\COMPTAGE\EVENEMENTS\" + Annee + "_" + Mois + "_" + Jour + "_Evenement_D1D2.txt"
        End If
        If My.Computer.FileSystem.FileExists(FICHIER_EVENEMENT_D1D2.ToString) Then
            My.Computer.FileSystem.DeleteFile(FICHIER_EVENEMENT_D1D2.ToString)
        End If
        ' MsgBox("/K CD C:\COMPTAGE\EVENEMENTS\ & TYPE " + FICHIER_EVENEMENT_D1 + " >> " + FICHIER_EVENEMENT_D1D2 + " & TYPE " + FICHIER_EVENEMENT_D2 + " >> " + FICHIER_EVENEMENT_D1D2 + " & move " + FICHIER_EVENEMENT_D1D2 + " C:\COMPTAGE\EVENEMENTS\CONTROLE\   & Exit")
        'MsgBox(Aujourdhui.ToString("d/MM/yyyy"))
        Process.Start("CMD.exe", "/K CD C:\COMPTAGE\EVENEMENTS\ & TYPE " + FICHIER_EVENEMENT_D1 + " >> " + FICHIER_EVENEMENT_D1D2 + " & TYPE " + FICHIER_EVENEMENT_D2 + " >> " + FICHIER_EVENEMENT_D1D2 + " & Exit")
        LireEvenement(FICHIER_EVENEMENT_D1D2, "le PC a reçu l'ACK de mémoire effacée du bus ") ' + ECRIRE_BUS
        AjouterValeur(FICHIER_BUS, FICHIER_VIDAGE_FINAL)
        Process.Start("CMD.exe", "/K move " + FICHIER_EVENEMENT_D1D2 + " C:\COMPTAGE\EVENEMENTS\CONTROLE\ & Exit")
        ExportToCSV(FICHIER_VIDAGE_FINAL)
    End Sub
End Class
