Imports NUnit.Framework

Public Class ArrayTests
    <Test()>
    Public Sub TestSingleDimensionalArray()

        ' test 1 - specify type explicitly
        Dim numbers = New Integer() {1, 2, 4, 8}
        Assert.AreEqual(8, numbers(3))
        Assert.AreEqual(3, numbers.GetUpperBound(0))
        Assert.That(4, [Is].EqualTo(numbers.GetLength(0)))

        ' test 2 - modify the array
        numbers(3) = 16
        Assert.That(numbers(3), [Is].Not.EqualTo(8))
        Assert.That(numbers(3), [Is].EqualTo(16))

        ' test 3 - type inference
        Dim doubles = {1.5, 9.9, 18, 0, 125, 2, 11.5}
        Assert.That(7, [Is].EqualTo(doubles.GetLength(0)))

        ' test 4 - sort the array
        Array.Sort(doubles)
        Assert.That(doubles, [Is].Ordered)

        ' test 5 - reverse the array
        Array.Reverse(doubles)
        Assert.That(doubles(0), [Is].EqualTo(125.0))

        ' test 6 - copy arrays by reference
        Dim moreNumbers = New Integer() {5, 7}
        moreNumbers = numbers
        Assert.That(moreNumbers(0), [Is].EqualTo(1))
        Assert.That(moreNumbers.GetUpperBound(0), [Is].EqualTo(numbers.GetUpperBound(0)))

        Dim length = moreNumbers.GetLength(0)
        For i As Integer = 0 To moreNumbers.GetUpperBound(0)
            moreNumbers(i) *= 2
        Next

        ' numbers and moreNumbers are referencing the same underlying array so both changed
        Assert.That(numbers, [Is].SameAs(moreNumbers))
        Assert.That(numbers(0), [Is].EqualTo(moreNumbers(0)))

        ' test 7 copy arrays by value
        length = numbers.GetLength(0)
        Dim copyOfNumbers(length) As Integer
        Array.Copy(numbers, copyOfNumbers, length)
        For i As Integer = 0 To numbers.GetUpperBound(0)
            moreNumbers(i) *= 2
        Next

        Assert.That(numbers, [Is].Not.SameAs(copyOfNumbers))
        Assert.That(numbers(0), [Is].Not.EqualTo(copyOfNumbers(0)))
    End Sub

    <Test()>
    Public Sub TestMultiDimenstionalArray()
        ' Test 1 - assert that all dimensions have the same length
        Dim numbers = {{1, 2}, {3, 4}, {5, 6}}
        Assert.That(numbers.GetLength(0), [Is].EqualTo(numbers.GetLength(1)))
        Assert.That(numbers.GetLength(0), [Is].EqualTo(numbers.GetLength(2)))

    End Sub
End Class
