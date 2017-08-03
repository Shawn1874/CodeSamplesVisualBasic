Imports NUnit.Framework

<TestFixture()>
Public Class StringsToOther
    <Test()>
    Public Sub StringToBooleanTest()
        Dim value As String = "True"
        Dim converted As Boolean
        Dim result = Boolean.TryParse(value, converted)
        Assert.AreEqual(True, result)
        Assert.AreEqual(True, converted)

        value = "False"
        result = Boolean.TryParse(value, converted)
        Assert.AreEqual(True, result)
        Assert.AreEqual(False, converted)

        ' Parse would throw if it fails so no return value is needed
        value = "False"
        converted = Boolean.Parse(value)
        Assert.AreEqual(False, converted)

        ' TryParse is case insensitive
        value = "false"
        result = Boolean.TryParse(value, converted)
        Assert.AreEqual(True, result)
        Assert.AreEqual(False, converted)

        value = "yes"
        result = Boolean.TryParse(value, converted)
        Assert.AreEqual(False, result)

        value = "1"
        result = Boolean.TryParse(value, converted)
        Assert.AreEqual(False, result)
    End Sub
End Class
