Module Looping

    Sub Main()
        ForEach_Accumulate()
    End Sub

    Sub ForEach_Accumulate()
        Dim nums() As Double = {10.5, 20.5, 30.5, 40.5, 50.5}
        Dim Total As Double = 0.0
        For Each value As Double In nums
            Total += value
        Next

        Console.WriteLine(String.Format("Total: {}", Total.ToString()))
    End Sub

End Module
