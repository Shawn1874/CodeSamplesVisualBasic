
Imports NUnit.Framework
Imports Looping
Imports VisualBasicFundamentals

<TestFixture()>
Public Class LoopingTests
    <Test()>
    Public Sub FactorialTest()
        Dim testObject As New ForLoops()

        ' Test 1 - 4! = 24
        Dim expected As Long = 24
        Dim result = testObject.Factorial(4)
        Assert.AreEqual(expected, result)

        ' Test 2 - 1! isn't supported
        expected = -1
        Assert.AreEqual(expected, testObject.Factorial(1))
    End Sub

    <Test()>
    Public Sub AddSeriesTest()
        Dim testObject As New ForLoops()

        ' Test 1 - Start = 5, Increment = 2, count = 5, expected = 60
        Assert.AreEqual(60, testObject.AddSeries(5, 5, 2))

        ' Test 2 - Start = 1, Increment = 1, count = 10, expected = 66
        ' 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10 + 11 = 
        Assert.AreEqual(66, testObject.AddSeries(1, 10, 1))
    End Sub
End Class