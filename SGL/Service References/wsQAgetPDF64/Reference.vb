﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace wsQAgetPDF64
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.CollectionDataContractAttribute(Name:="ArrayOfString", [Namespace]:="DBNET", ItemName:="string"),  _
     System.SerializableAttribute()>  _
    Public Class ArrayOfString
        Inherits System.Collections.Generic.List(Of String)
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="DBNET", ConfigurationName:="wsQAgetPDF64.getPDF64Soap")>  _
    Public Interface getPDF64Soap
        
        'CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento rutt del espacio de nombres DBNET no está marcado para aceptar valores nil.
        <System.ServiceModel.OperationContractAttribute(Action:="DBNET/get_pdf", ReplyAction:="*")>  _
        Function get_pdf(ByVal request As wsQAgetPDF64.get_pdfRequest) As wsQAgetPDF64.get_pdfResponse
        
        'CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento sRutt del espacio de nombres DBNET no está marcado para aceptar valores nil.
        <System.ServiceModel.OperationContractAttribute(Action:="DBNET/get_pdf_sucursal", ReplyAction:="*")>  _
        Function get_pdf_sucursal(ByVal request As wsQAgetPDF64.get_pdf_sucursalRequest) As wsQAgetPDF64.get_pdf_sucursalResponse
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class get_pdfRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="get_pdf", [Namespace]:="DBNET", Order:=0)>  _
        Public Body As wsQAgetPDF64.get_pdfRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As wsQAgetPDF64.get_pdfRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="DBNET")>  _
    Partial Public Class get_pdfRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public rutt As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public folio As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=2)>  _
        Public doc As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=3)>  _
        Public monto As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=4)>  _
        Public fecha As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=5)>  _
        Public ruttt As String
        
        <System.Runtime.Serialization.DataMemberAttribute(Order:=6)>  _
        Public Merito As Boolean
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal rutt As String, ByVal folio As String, ByVal doc As String, ByVal monto As String, ByVal fecha As String, ByVal ruttt As String, ByVal Merito As Boolean)
            MyBase.New
            Me.rutt = rutt
            Me.folio = folio
            Me.doc = doc
            Me.monto = monto
            Me.fecha = fecha
            Me.ruttt = ruttt
            Me.Merito = Merito
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class get_pdfResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="get_pdfResponse", [Namespace]:="DBNET", Order:=0)>  _
        Public Body As wsQAgetPDF64.get_pdfResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As wsQAgetPDF64.get_pdfResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="DBNET")>  _
    Partial Public Class get_pdfResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public get_pdfResult As wsQAgetPDF64.ArrayOfString
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal get_pdfResult As wsQAgetPDF64.ArrayOfString)
            MyBase.New
            Me.get_pdfResult = get_pdfResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class get_pdf_sucursalRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="get_pdf_sucursal", [Namespace]:="DBNET", Order:=0)>  _
        Public Body As wsQAgetPDF64.get_pdf_sucursalRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As wsQAgetPDF64.get_pdf_sucursalRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="DBNET")>  _
    Partial Public Class get_pdf_sucursalRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public sRutt As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public sFolio As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=2)>  _
        Public sDoc As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=3)>  _
        Public sMonto As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=4)>  _
        Public sFecha As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=5)>  _
        Public sRuttt As String
        
        <System.Runtime.Serialization.DataMemberAttribute(Order:=6)>  _
        Public bMerito As Boolean
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal sRutt As String, ByVal sFolio As String, ByVal sDoc As String, ByVal sMonto As String, ByVal sFecha As String, ByVal sRuttt As String, ByVal bMerito As Boolean)
            MyBase.New
            Me.sRutt = sRutt
            Me.sFolio = sFolio
            Me.sDoc = sDoc
            Me.sMonto = sMonto
            Me.sFecha = sFecha
            Me.sRuttt = sRuttt
            Me.bMerito = bMerito
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class get_pdf_sucursalResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="get_pdf_sucursalResponse", [Namespace]:="DBNET", Order:=0)>  _
        Public Body As wsQAgetPDF64.get_pdf_sucursalResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As wsQAgetPDF64.get_pdf_sucursalResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="DBNET")>  _
    Partial Public Class get_pdf_sucursalResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public get_pdf_sucursalResult As wsQAgetPDF64.ArrayOfString
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal get_pdf_sucursalResult As wsQAgetPDF64.ArrayOfString)
            MyBase.New
            Me.get_pdf_sucursalResult = get_pdf_sucursalResult
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface getPDF64SoapChannel
        Inherits wsQAgetPDF64.getPDF64Soap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class getPDF64SoapClient
        Inherits System.ServiceModel.ClientBase(Of wsQAgetPDF64.getPDF64Soap)
        Implements wsQAgetPDF64.getPDF64Soap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function wsQAgetPDF64_getPDF64Soap_get_pdf(ByVal request As wsQAgetPDF64.get_pdfRequest) As wsQAgetPDF64.get_pdfResponse Implements wsQAgetPDF64.getPDF64Soap.get_pdf
            Return MyBase.Channel.get_pdf(request)
        End Function
        
        Public Function get_pdf(ByVal rutt As String, ByVal folio As String, ByVal doc As String, ByVal monto As String, ByVal fecha As String, ByVal ruttt As String, ByVal Merito As Boolean) As wsQAgetPDF64.ArrayOfString
            Dim inValue As wsQAgetPDF64.get_pdfRequest = New wsQAgetPDF64.get_pdfRequest()
            inValue.Body = New wsQAgetPDF64.get_pdfRequestBody()
            inValue.Body.rutt = rutt
            inValue.Body.folio = folio
            inValue.Body.doc = doc
            inValue.Body.monto = monto
            inValue.Body.fecha = fecha
            inValue.Body.ruttt = ruttt
            inValue.Body.Merito = Merito
            Dim retVal As wsQAgetPDF64.get_pdfResponse = CType(Me,wsQAgetPDF64.getPDF64Soap).get_pdf(inValue)
            Return retVal.Body.get_pdfResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function wsQAgetPDF64_getPDF64Soap_get_pdf_sucursal(ByVal request As wsQAgetPDF64.get_pdf_sucursalRequest) As wsQAgetPDF64.get_pdf_sucursalResponse Implements wsQAgetPDF64.getPDF64Soap.get_pdf_sucursal
            Return MyBase.Channel.get_pdf_sucursal(request)
        End Function
        
        Public Function get_pdf_sucursal(ByVal sRutt As String, ByVal sFolio As String, ByVal sDoc As String, ByVal sMonto As String, ByVal sFecha As String, ByVal sRuttt As String, ByVal bMerito As Boolean) As wsQAgetPDF64.ArrayOfString
            Dim inValue As wsQAgetPDF64.get_pdf_sucursalRequest = New wsQAgetPDF64.get_pdf_sucursalRequest()
            inValue.Body = New wsQAgetPDF64.get_pdf_sucursalRequestBody()
            inValue.Body.sRutt = sRutt
            inValue.Body.sFolio = sFolio
            inValue.Body.sDoc = sDoc
            inValue.Body.sMonto = sMonto
            inValue.Body.sFecha = sFecha
            inValue.Body.sRuttt = sRuttt
            inValue.Body.bMerito = bMerito
            Dim retVal As wsQAgetPDF64.get_pdf_sucursalResponse = CType(Me,wsQAgetPDF64.getPDF64Soap).get_pdf_sucursal(inValue)
            Return retVal.Body.get_pdf_sucursalResult
        End Function
    End Class
End Namespace