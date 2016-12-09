Public Class Form1
    Private Function GetStudents() As List(Of Student)
        Return New List(Of Student) From
        {
           New Student With {.StudentID = 1, .StudentName = "Hannes du Preez",
              .CourseID = 3, .StudentAge = 38},
           New Student With {.StudentID = 2, .StudentName = "Elmarie du Preez",
              .CourseID = 1, .StudentAge = 38},
           New Student With {.StudentID = 3, .StudentName = "Michaela du Preez",
              .CourseID = 2, .StudentAge = 16}
        }
    End Function
    Private Function GetCourses() As List(Of Course)
        Return New List(Of Course) From
           {
              New Course With {.CourseID = 1, .CourseName = "Programming",
                 .CourseDuration = 5},
              New Course With {.CourseID = 2, .CourseName = "Introduction to PCs",
                 .CourseDuration = 12},
              New Course With {.CourseID = 3, .CourseName = "Graphic Design",
                 .CourseDuration = 4}
           }
    End Function

    Private Sub GetStudents_MouseClick(sender As Object, e As MouseEventArgs) Handles Button1.MouseClick
        Dim students = GetStudents()
        Dim queryResults = From stu In students
        For Each result In queryResults
            Debug.WriteLine(result.StudentID.ToString() & " " & result.StudentName &
               " " & result.StudentAge.ToString() & " " & result.CourseID.ToString())
        Next
    End Sub

    Private Sub GetCourses_MouseClick(sender As Object, e As MouseEventArgs) Handles Button2.MouseClick
        Dim courses = GetCourses()
        Dim queryResults = From cour In courses
        For Each result In queryResults
            Debug.WriteLine(result.CourseID.ToString() & " " & result.CourseName &
               " " & result.CourseDuration.ToString())
        Next
    End Sub

    Private Sub Where_MouseClick(sender As Object, e As MouseEventArgs) Handles Button3.MouseClick
        Dim students = GetStudents()
        Dim queryResults = From stu In students
                           Where stu.CourseID = 3
        For Each result In queryResults
            Debug.WriteLine(result.StudentID.ToString() & " " _
               & result.StudentName & " " & result.StudentAge.ToString() & " " _
               & result.CourseID.ToString())
        Next
    End Sub

    Private Sub Select_MouseClick(sender As Object, e As MouseEventArgs) Handles Button4.MouseClick
        Dim courses = GetCourses()
        Dim queryResults = From cour In courses
                           Where cour.CourseID = 3
                           Select cour.CourseName, cour.CourseDuration
        For Each result In queryResults
            Debug.WriteLine(result.CourseName & " " _
               & result.CourseDuration.ToString())
        Next
    End Sub

    Private Sub Combine_Clicked(sender As Object, e As EventArgs) Handles Button5.Click
        Dim students = GetStudents()
        Dim courses = GetCourses()
        Dim queryResults = From stu In students, cour In courses
                           Where stu.CourseID = cour.CourseID
                           Select stu, cour
        For Each result In queryResults
            Debug.WriteLine(result.stu.StudentName & " " _
               & result.cour.CourseName)
        Next
    End Sub
End Class
