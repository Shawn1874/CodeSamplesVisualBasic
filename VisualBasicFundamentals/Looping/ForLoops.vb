Public Class ForLoops

    ' value - any integer greater than 1
    ' return - value! or -1 if value is not valid
    Public Function Factorial(value As Int32) As Long
        Dim result As Long = -1
        If (value > 1) Then
            result = value
            For current As Int32 = value To 2 Step -1
                result = result * (current - 1)
            Next
        End If
        Return result
    End Function

    ' example start = 5, count = 5, step = 2
    ' result = 5 + 7 + 9 + 11 + 13 + 15 = 60
    Public Function AddSeries(start As Int32, count As Int32, increment As Int16) As Int32
        Dim result As Int32 = start
        For current = 1 To count
            result += start + increment * current
        Next
        Return result
    End Function
End Class
