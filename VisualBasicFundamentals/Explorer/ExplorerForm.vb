Imports System.IO

Public Class ExplorerForm

    Private Sub ExplorerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewComboBox.SelectedIndex = 0
        Dim docs As New TreeNode("C5 Docs")
        docs.Tag = "E:\C5 Docs"
        FileTree.Nodes.Add(docs)
        GetFolders(docs)

        docs.Expand() '

        ListView1.Columns.Add("Name", 250)
        ListView1.Columns.Add("Date modified", 150)
        ListView1.Columns.Add("Size", 75, HorizontalAlignment.Right)
    End Sub

    Private Sub GetFolders(node As TreeNode)
        Try
            Dim dir As New DirectoryInfo(node.Tag)
            For Each childDir In dir.GetDirectories()
                If childDir.Attributes.HasFlag(FileAttributes.Hidden) Then
                    Continue For
                End If
                Dim childNode As New TreeNode(childDir.Name)
                childNode.Tag = childDir.FullName
                node.Nodes.Add(childNode)
                GetFolders(childNode)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FileTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FileTree.AfterSelect
        Dim dir As New DirectoryInfo(e.Node.Tag)
        ListView1.Items.Clear()
        LargeImageList.Images.RemoveByKey(".exe")
        For Each thisFile In dir.GetFiles()
            Dim item As New ListViewItem(thisFile.Name)
            Dim lastWrite = thisFile.LastWriteTime
            item.SubItems.Add(lastWrite.ToShortDateString() & " " & lastWrite.ToShortTimeString())
            item.SubItems.Add(Math.Ceiling(thisFile.Length / 1024) & " KB")
            If Not LargeImageList.Images.ContainsKey(thisFile.Extension) Then
                Dim thisIcon = Icon.ExtractAssociatedIcon(thisFile.FullName)
                LargeImageList.Images.Add(thisFile.Extension, thisIcon)
                SmallImageList.Images.Add(thisFile.Extension, thisIcon)
            End If
            item.ImageKey = thisFile.Extension
            ListView1.Items.Add(item)

        Next
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ViewLabel.Click

    End Sub

    Private Sub ViewComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ViewComboBox.SelectedIndexChanged
        Select Case ViewComboBox.Text
            Case "Large Icons"
                ListView1.View = View.LargeIcon
            Case "Small Icons"
                ListView1.View = View.SmallIcon
            Case "Details"
                ListView1.View = View.Details
        End Select
    End Sub
End Class
