﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HardwareInventoryService.ServicesReferences.AuthorizationServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Session", Namespace="http://schemas.datacontract.org/2004/07/HardwareInventoryService.Models.Models.Au" +
        "thorization")]
    [System.SerializableAttribute()]
    public partial class Session : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ConnectionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime[] FailedLoginAttemptsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TokenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> TokenValidityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ConnectionId {
            get {
                return this.ConnectionIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ConnectionIdField, value) != true)) {
                    this.ConnectionIdField = value;
                    this.RaisePropertyChanged("ConnectionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime[] FailedLoginAttempts {
            get {
                return this.FailedLoginAttemptsField;
            }
            set {
                if ((object.ReferenceEquals(this.FailedLoginAttemptsField, value) != true)) {
                    this.FailedLoginAttemptsField = value;
                    this.RaisePropertyChanged("FailedLoginAttempts");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Token {
            get {
                return this.TokenField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenField, value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> TokenValidity {
            get {
                return this.TokenValidityField;
            }
            set {
                if ((this.TokenValidityField.Equals(value) != true)) {
                    this.TokenValidityField = value;
                    this.RaisePropertyChanged("TokenValidity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/HardwareInventoryService.Models.Models")]
    [System.SerializableAttribute()]
    public partial class ExceptionDetail : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> BlockedTillField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExceptionTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> LoginAttemptsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.ErrorCode StatusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> BlockedTill {
            get {
                return this.BlockedTillField;
            }
            set {
                if ((this.BlockedTillField.Equals(value) != true)) {
                    this.BlockedTillField = value;
                    this.RaisePropertyChanged("BlockedTill");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExceptionType {
            get {
                return this.ExceptionTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ExceptionTypeField, value) != true)) {
                    this.ExceptionTypeField = value;
                    this.RaisePropertyChanged("ExceptionType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> LoginAttempts {
            get {
                return this.LoginAttemptsField;
            }
            set {
                if ((this.LoginAttemptsField.Equals(value) != true)) {
                    this.LoginAttemptsField = value;
                    this.RaisePropertyChanged("LoginAttempts");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.ErrorCode Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ErrorCode", Namespace="http://schemas.datacontract.org/2004/07/HardwareInventoryService.Models.Models.En" +
        "ums")]
    public enum ErrorCode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ConnectionError = 1000,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ArgumentNullError = 1001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NotFoundInCache = 3001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SessionError = 4001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AccountBlocked = 4002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PassAlreadyUsedError = 4003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Undefined = 0,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthorizationServiceReference.IAuthorizationWCFContract")]
    public interface IAuthorizationWCFContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorizationWCFContract/Authorize", ReplyAction="http://tempuri.org/IAuthorizationWCFContract/AuthorizeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.ExceptionDetail), Action="http://tempuri.org/IAuthorizationWCFContract/AuthorizeExceptionDetailFault", Name="ExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/HardwareInventoryService.Models.Models")]
        HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session Authorize(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorizationWCFContract/Authorize", ReplyAction="http://tempuri.org/IAuthorizationWCFContract/AuthorizeResponse")]
        System.Threading.Tasks.Task<HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session> AuthorizeAsync(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorizationWCFContract/Deauthorize", ReplyAction="http://tempuri.org/IAuthorizationWCFContract/DeauthorizeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.ExceptionDetail), Action="http://tempuri.org/IAuthorizationWCFContract/DeauthorizeExceptionDetailFault", Name="ExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/HardwareInventoryService.Models.Models")]
        bool Deauthorize(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorizationWCFContract/Deauthorize", ReplyAction="http://tempuri.org/IAuthorizationWCFContract/DeauthorizeResponse")]
        System.Threading.Tasks.Task<bool> DeauthorizeAsync(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorizationWCFContract/ChangePassword", ReplyAction="http://tempuri.org/IAuthorizationWCFContract/ChangePasswordResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.ExceptionDetail), Action="http://tempuri.org/IAuthorizationWCFContract/ChangePasswordExceptionDetailFault", Name="ExceptionDetail", Namespace="http://schemas.datacontract.org/2004/07/HardwareInventoryService.Models.Models")]
        bool ChangePassword(string username, string password, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthorizationWCFContract/ChangePassword", ReplyAction="http://tempuri.org/IAuthorizationWCFContract/ChangePasswordResponse")]
        System.Threading.Tasks.Task<bool> ChangePasswordAsync(string username, string password, string newPassword);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthorizationWCFContractChannel : HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.IAuthorizationWCFContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthorizationWCFContractClient : System.ServiceModel.ClientBase<HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.IAuthorizationWCFContract>, HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.IAuthorizationWCFContract {
        
        public AuthorizationWCFContractClient() {
        }
        
        public AuthorizationWCFContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthorizationWCFContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorizationWCFContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorizationWCFContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session Authorize(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData) {
            return base.Channel.Authorize(authData);
        }
        
        public System.Threading.Tasks.Task<HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session> AuthorizeAsync(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData) {
            return base.Channel.AuthorizeAsync(authData);
        }
        
        public bool Deauthorize(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData) {
            return base.Channel.Deauthorize(authData);
        }
        
        public System.Threading.Tasks.Task<bool> DeauthorizeAsync(HardwareInventoryService.ServicesReferences.AuthorizationServiceReference.Session authData) {
            return base.Channel.DeauthorizeAsync(authData);
        }
        
        public bool ChangePassword(string username, string password, string newPassword) {
            return base.Channel.ChangePassword(username, password, newPassword);
        }
        
        public System.Threading.Tasks.Task<bool> ChangePasswordAsync(string username, string password, string newPassword) {
            return base.Channel.ChangePasswordAsync(username, password, newPassword);
        }
    }
}
