Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace NavBarExample.Web
	Partial Public Class NavBarExampleAspNetApplication
		Inherits WebApplication
		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
		Private module3 As NavBarExample.Module.NavBarExampleModule
		Private module4 As NavBarExample.Module.Web.NavBarExampleAspNetModule
		Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
		Private securitySimple As DevExpress.ExpressApp.Security.SecurityStrategySimple
		Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
		Private authenticationActiveDirectory1 As DevExpress.ExpressApp.Security.AuthenticationActiveDirectory
		Private sqlConnection1 As System.Data.SqlClient.SqlConnection
		Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub NavBarExampleAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
			e.Updater.Update()
			e.Handled = True
#Else
			If System.Diagnostics.Debugger.IsAttached Then
				e.Updater.Update()
				e.Handled = True
			Else
				Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & Constants.vbCrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & Constants.vbCrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & Constants.vbCrLf & "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
			End If
#End If
		End Sub

		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
			Me.module3 = New NavBarExample.Module.NavBarExampleModule()
			Me.module4 = New NavBarExample.Module.Web.NavBarExampleAspNetModule()
			Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
			Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
			Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
			Me.securitySimple = New DevExpress.ExpressApp.Security.SecurityStrategySimple()
			Me.authenticationActiveDirectory1 = New DevExpress.ExpressApp.Security.AuthenticationActiveDirectory()
			Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' securitySimple1
			' 
			Me.securitySimple.Authentication = Me.authenticationActiveDirectory1
			Me.securitySimple.UserType = GetType(DevExpress.ExpressApp.Security.SecuritySimpleUser)
			' 
			' authenticationActiveDirectory1
			' 
			Me.authenticationActiveDirectory1.CreateUserAutomatically = True
			Me.authenticationActiveDirectory1.UserType = GetType(DevExpress.ExpressApp.Security.SecuritySimpleUser)
			' 
			' sqlConnection1
			' 
			Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=NavBarExample;Integrated Security=SSPI;Pooling=false"
			Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
			' 
			' NavBarExampleAspNetApplication
			' 
			Me.ApplicationName = "NavBarExample"
			Me.Connection = Me.sqlConnection1
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.module4)
			Me.Modules.Add(Me.module5)
			Me.Modules.Add(Me.module6)

			Me.Modules.Add(Me.securityModule1)
			Me.Security = Me.securitySimple
'			Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.NavBarExampleAspNetApplication_DatabaseVersionMismatch);
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
	End Class
End Namespace
