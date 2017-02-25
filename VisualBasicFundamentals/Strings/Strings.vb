Imports System.Text

Module Strings

    Sub Main()
        StringsAreImmutable()
        FormattingWithNumbers()
    End Sub

    Sub FormattingWithNumbers()
        Console.WriteLine("Enter FormattingWithNumbers")
        Dim f As Double = 100.0
        Dim s As Short = -25

        Console.WriteLine(String.Format("min Short = {0}, max Short = {1}", Short.MinValue, Short.MaxValue))
        Console.WriteLine(String.Format("min Integer = {0}, max Integer = {1}", Integer.MinValue.ToString("G4"), Integer.MaxValue.ToString("G4")))
        Console.WriteLine(String.Format("min Long = {0}, max Long = {1}", Long.MinValue.ToString("g5"), Long.MaxValue.ToString("g5")))
        Console.WriteLine(String.Format("min Single = {0}, max Single = {1}", Single.MinValue, Single.MaxValue))
        Console.WriteLine(String.Format("min Double = {0}, max Double = {1}", Double.MinValue, Double.MaxValue))
        Console.WriteLine("Exit FormattingWithNumbers")
    End Sub

    Sub StringsAreImmutable()
        Console.WriteLine("Enter StringsAreImmutable")
        Dim name As String = "Shawn"
        Dim upperName As String = name.ToUpper()
        Dim lastName = "Fox"
        Dim fullName As New StringBuilder()
        fullName.AppendFormat("{0} {1}", name, lastName)
        fullName.Insert(5, " D.")

        Console.WriteLine(name)
        Console.WriteLine(upperName)
        Console.WriteLine(fullName)

        Dim phrase As New StringBuilder("teh cow jumped over teh moon")
        Console.WriteLine(String.Format("Original: {0}", phrase))
        phrase.Replace("teh", "the")
        Console.WriteLine(String.Format("Fixed: {0}", phrase))
        Console.WriteLine(phrase) ' "the cow jumped over the moon" - a string builder is mutable

        Dim sentence As String = "teh cow jumped over teh moon"
        sentence.Replace("teh", "the")
        Console.WriteLine(sentence) ' sentence didn't change!

        Console.WriteLine("Exit StringsAreImmutable")
    End Sub

End Module
