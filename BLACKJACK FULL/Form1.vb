Imports System.Deployment.Application
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form1
    Public player1 As Double
    Public player2 As Double
    Public player3 As Double
    Public player4 As Double
    Public player5 As Double
    Public player6 As Double

    Public dealer1 As Double
    Public dealer2 As Double
    Public dealer3 As Double
    Public dealer4 As Double
    Public dealer5 As Double
    Public dealer6 As Double

    Public totalplayercard As Double
    Public totaldealercard As Double

    Public loopcheck As Double
    Public startcheck As Double
    Public hitcheck As Double
    Public standcheck As Double
    Public gameover As Double

    Public deck(51) As String
    Public ShuffledDeck(51) As String
    Public ShuffledDeckValues(51) As Integer
    Public Masterdeck() As String = {"2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "10h", "Jh", "Qh", "Kh", "Ah", "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "10d", "Jd", "Qd", "Kd", "Ad", "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "10c", "Jc", "Qc", "Kc", "Ac", "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "10s", "Js", "Qs", "Ks", "As"}
    Public PulledCrardIndex As Integer
    Public CurrentCardValue As Integer
    Public CurrentCardName As String
    Public d2CardName As String

    Public bet As Integer = 0
    Public balance As Integer = 1000

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pBalance.Text = balance
        pBet.Text = 0
        pWin.Text = 0
    End Sub

    Private Sub start_Click(sender As Object, e As EventArgs) Handles start.Click
        If startcheck = 1 Then
            MessageBox.Show("you already started")
        ElseIf bet = 0 Then
            MessageBox.Show("bet is 0")
        ElseIf startcheck = 0 Then
            PulledCrardIndex = 0
            CurrentCardValue = 0
            CurrentCardName = ""
            d2CardName = ""
            create_a_deck()
            shuffle_deck()

            balance -= bet
            pBalance.Text = balance

            player1 = pullcard()
            p1.Text = CurrentCardValue
            p1Card.Text = CurrentCardName
            player2 = pullcard()
            p2.Text = CurrentCardValue
            p2Card.Text = CurrentCardName

            dealer1 = pullcard()
            d1.Text = CurrentCardValue
            d1Card.Text = CurrentCardName
            dealer2 = pullcard()
            d2.Text = "hidden"
            d2CardName = CurrentCardName

            startcheck = 1
            hitcheck = 1
            standcheck = 1
            totalplayercard = player1 + player2

            pTotal.Text = totalplayercard
            dTotal.Text = ""

            If totalplayercard = 21 Then
                MessageBox.Show("youwin")
                gameover = 1
            End If
        End If
    End Sub

    Private Sub hit_Click(sender As Object, e As EventArgs) Handles hit.Click
        If gameover = 1 Then
            MessageBox.Show("game is over hit reset")
        ElseIf gameover = 0 Then
            If hitcheck = 0 Then
                MessageBox.Show("hit start")
            ElseIf hitcheck = 4 Then
                player6 = pullcard()
                p6.Text = CurrentCardValue
                p6Card.Text = CurrentCardName
                hitcheck = 5
            ElseIf hitcheck = 3 Then
                player5 = pullcard()
                p5.Text = CurrentCardValue
                p5Card.Text = CurrentCardName
                hitcheck = 4
            ElseIf hitcheck = 2 Then
                player4 = pullcard()
                p4.Text = CurrentCardValue
                p4Card.Text = CurrentCardName
                hitcheck = 3
            ElseIf hitcheck = 1 Then
                player3 = pullcard()
                p3.Text = CurrentCardValue
                p3Card.Text = CurrentCardName
                hitcheck = 2

            End If

            totalplayercard = player1 + player2 + player3 + player4 + player5 + player6
            If totalplayercard > 21 Then
                If player1 = 11 Then
                    player1 = 1
                    p1.Text = player1 & " was 11"
                ElseIf player2 = 11 Then
                    player2 = 1
                    p2.Text = player2 & " was 11"
                ElseIf player3 = 11 Then
                    player3 = 1
                    p3.Text = player3 & " was 11"
                ElseIf player4 = 11 Then
                    player4 = 1
                    p4.Text = player4 & "was 11"
                ElseIf player5 = 11 Then
                    player5 = 1
                    p5.Text = player5 & "was11"
                ElseIf player6 = 11 Then
                    player6 = 1
                    p6.Text = player6 & "was 11 "

                End If
            End If
            totalplayercard = player1 + player2 + player3 + player4 + player5 + player6
            pTotal.Text = totalplayercard
            If totalplayercard > 21 Then
                MessageBox.Show("you lose")
                gameover = 1
            ElseIf totalplayercard = 21 Then
                balance += bet * 2
                pBalance.Text = balance
                pWin.Text = bet * 2
                gameover = 1
                MessageBox.Show("you win")
            End If
        End If
    End Sub

    Private Sub stand_Click(sender As Object, e As EventArgs) Handles stand.Click
        If gameover = 1 Then
            MessageBox.Show("hit reset first ")
        ElseIf gameover = 0 Then
            If standcheck = 0 Then
                MessageBox.Show("hit start first")
            ElseIf standcheck = 1 Then
                d2.Text = dealer2
                d2Card.Text = d2CardName
                totaldealercard = dealer1 + dealer2
                dTotal.Text = totaldealercard
                If totaldealercard >= 17 Then
                ElseIf totaldealercard < 17 Then
                    Do While loopcheck = 0
                        Select Case standcheck
                            Case 4
                                dealer6 = pullcard()
                                d6.Text = CurrentCardValue
                                d6Card.Text = CurrentCardName
                                loopcheck = 1
                            Case 3
                                dealer5 = pullcard()
                                d5.Text = CurrentCardValue
                                d5Card.Text = CurrentCardName
                                standcheck = 4
                            Case 2
                                dealer4 = pullcard()
                                d4.Text = CurrentCardValue
                                d4Card.Text = CurrentCardName
                                standcheck = 3
                            Case 1
                                dealer3 = pullcard()
                                d3.Text = CurrentCardValue
                                d3Card.Text = CurrentCardName
                                standcheck = 2
                        End Select
                        totaldealercard = dealer1 + dealer2 + dealer3 + dealer4 + dealer5 + dealer6
                        If totaldealercard > 21 Then
                            If dealer1 = 11 Then
                                dealer1 = 1
                                d1.Text = dealer1 & ("was11")
                            ElseIf dealer2 = 11 Then
                                dealer2 = 1
                                d2.Text = dealer2 & ("was11")
                            ElseIf dealer3 = 11 Then
                                dealer3 = 1
                                d3.Text = dealer3 & ("was 11")
                            ElseIf dealer4 = 11 Then
                                dealer4 = 1
                                d4.Text = dealer4 & ("was11")
                            ElseIf dealer5 = 11 Then
                                dealer5 = 1
                                d5.Text = dealer5 & ("was11")
                            ElseIf dealer6 = 11 Then
                                dealer6 = 1
                                d6.Text = dealer6 & ("was 11")

                            End If
                        End If
                        totaldealercard = dealer1 + dealer2 + dealer3 + dealer4 + dealer5 + dealer6
                        dTotal.Text = totaldealercard
                        If totaldealercard >= 17 Then
                            loopcheck = 1

                        End If
                    Loop


                End If
                If totaldealercard > 21 Then
                    balance += bet * 2
                    pBalance.Text = balance
                    pWin.Text = bet * 2
                    gameover = 1
                    MessageBox.Show("you win")
                ElseIf totaldealercard <= 21 Then
                    If totalplayercard > totaldealercard Then
                        balance += bet * 2
                        pBalance.Text = balance
                        pWin.Text = bet * 2
                        gameover = 1
                        MessageBox.Show("you win")
                    Else
                        gameover = 1
                        MessageBox.Show("youlose ")

                    End If
                End If

            End If
        End If
    End Sub

    Private Sub reset_Click(sender As Object, e As EventArgs) Handles reset.Click
        PulledCrardIndex = 0
        deck = New String(51) {}
        ShuffledDeck = New String(51) {}
        ShuffledDeckValues = New Integer(51) {}

        player1 = 0
        player2 = 0
        player3 = 0
        player4 = 0
        player5 = 0
        player6 = 0

        dealer1 = 0
        dealer2 = 0
        dealer3 = 0
        dealer4 = 0
        dealer5 = 0
        dealer6 = 0


        totaldealercard = 0

        totalplayercard = 0

        loopcheck = 0
        startcheck = 0
        hitcheck = 0
        standcheck = 0
        gameover = 0

        p1.Text = 0
        p2.Text = 0
        p3.Text = 0
        p4.Text = 0
        p5.Text = 0
        p6.Text = 0

        p1Card.Text = ""
        p2Card.Text = ""
        p3Card.Text = ""
        p4Card.Text = ""
        p5Card.Text = ""
        p6Card.Text = ""

        d1.Text = 0
        d2.Text = 0
        d3.Text = 0
        d4.Text = 0
        d5.Text = 0
        d6.Text = 0

        d1Card.Text = ""
        d2Card.Text = ""
        d3Card.Text = ""
        d4Card.Text = ""
        d5Card.Text = ""
        d6Card.Text = ""

        pTotal.Text = 0
        dTotal.Text = 0

        d2CardName = ""

        bet = 0
        pBet.Text = 0
        pWin.Text = 0

    End Sub

    Function pullcard() As Double
        CurrentCardValue = ShuffledDeckValues(PulledCrardIndex)
        CurrentCardName = ShuffledDeck(PulledCrardIndex)
        PulledCrardIndex += 1
        Return CurrentCardValue
    End Function

    Function create_a_deck() As String()
        deck = New String(51) {}
        Dim i As Integer = 0
        For i = 0 To 51
            deck(i) = Masterdeck(i)
        Next i
        Return deck
    End Function

    Function shuffle_deck() As String()
        ShuffledDeck = New String(51) {}
        ShuffledDeckValues = New Integer(51) {}
        Dim i As Integer = 0
        Dim R As New Random
        Dim card As String = "X"
        Dim index As Integer = 0

        For i = 0 To 51
            index = R.Next(0, deck.Length)
            card = deck(index)
            If card = "X" Then
                Do
                    index += 1
                    If index > 51 Then
                        index = 0
                    End If
                Loop While deck(index) = "X"

                card = deck(index)
            End If

            ShuffledDeck(i) = card
            ShuffledDeckValues(i) = get_card_value(card)

            deck(index) = "X"
        Next i

        Return ShuffledDeck
    End Function

    Function get_card_value(card_name As String) As Integer
        If card_name = "2c" Or card_name = "2h" Or card_name = "2s" Or card_name = "2d" Then
            Return 2
        ElseIf card_name = "3c" Or card_name = "3h" Or card_name = "3s" Or card_name = "3d" Then
            Return 3
        ElseIf card_name = "4c" Or card_name = "4h" Or card_name = "4s" Or card_name = "4d" Then
            Return 4
        ElseIf card_name = "5c" Or card_name = "5h" Or card_name = "5s" Or card_name = "5d" Then
            Return 5
        ElseIf card_name = "6c" Or card_name = "6h" Or card_name = "6s" Or card_name = "6d" Then
            Return 6
        ElseIf card_name = "7c" Or card_name = "7h" Or card_name = "7s" Or card_name = "7d" Then
            Return 7
        ElseIf card_name = "8c" Or card_name = "8h" Or card_name = "8s" Or card_name = "8d" Then
            Return 8
        ElseIf card_name = "9c" Or card_name = "9h" Or card_name = "9s" Or card_name = "9d" Then
            Return 9
        ElseIf card_name = "10c" Or card_name = "10h" Or card_name = "10s" Or card_name = "10d" Then
            Return 10
        ElseIf card_name = "Jc" Or card_name = "Jh" Or card_name = "Js" Or card_name = "Jd" Then
            Return 10
        ElseIf card_name = "Qc" Or card_name = "Qh" Or card_name = "Qs" Or card_name = "Qd" Then
            Return 10
        ElseIf card_name = "Kc" Or card_name = "Kh" Or card_name = "Ks" Or card_name = "Kd" Then
            Return 10
        ElseIf card_name = "Ac" Or card_name = "Ah" Or card_name = "As" Or card_name = "Ad" Then
            Return 11
        End If
        Return 0
    End Function

    Private Sub pBet1_Click(sender As Object, e As EventArgs) Handles pBet1.Click
        Dim playerBalance As Integer = balance
        playerBalance = balance - bet - 1
        If playerBalance >= 0 Then
            bet += 1
            pBet.Text = bet
        Else
            MessageBox.Show("insufficient balance")
        End If
    End Sub

    Private Sub pBet5_Click(sender As Object, e As EventArgs) Handles pBet5.Click
        Dim playerBalance As Integer = balance
        playerBalance = balance - bet - 5
        If playerBalance >= 0 Then
            bet += 5
            pBet.Text = bet
        Else
            MessageBox.Show("insufficient balance")
        End If
    End Sub

    Private Sub pBet25_Click(sender As Object, e As EventArgs) Handles pBet25.Click
        Dim playerBalance As Integer = balance
        playerBalance = balance - bet - 25
        If playerBalance >= 0 Then
            bet += 25
            pBet.Text = bet
        Else
            MessageBox.Show("insufficient balance")
        End If
    End Sub

    Private Sub pBet50_Click(sender As Object, e As EventArgs) Handles pBet50.Click
        Dim playerBalance As Integer = balance
        playerBalance = balance - bet - 50
        If playerBalance >= 0 Then
            bet += 50
            pBet.Text = bet
        Else
            MessageBox.Show("insufficient balance")
        End If
    End Sub

    Private Sub pBet100_Click(sender As Object, e As EventArgs) Handles pBet100.Click
        Dim playerBalance As Integer = balance
        playerBalance = balance - bet - 100
        If playerBalance >= 0 Then
            bet += 100
            pBet.Text = bet
        Else
            MessageBox.Show("insufficient balance")
        End If
    End Sub

    Private Sub pResetBet_Click(sender As Object, e As EventArgs) Handles pResetBet.Click
        bet = 0
        pBet.Text = bet
    End Sub

End Class
