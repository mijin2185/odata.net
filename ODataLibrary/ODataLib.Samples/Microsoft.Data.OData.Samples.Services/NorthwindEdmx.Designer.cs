//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Products_Categories", "Categories", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Microsoft.Data.OData.Sample.Services.Category), "Products", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Product), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Orders_Customers", "Customers", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Microsoft.Data.OData.Sample.Services.Customer), "Orders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Order), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Employees_Employees", "Employees", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Microsoft.Data.OData.Sample.Services.Employee), "Employees1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Employee), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Orders_Employees", "Employees", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Microsoft.Data.OData.Sample.Services.Employee), "Orders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Order), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Order_Details_Orders", "Orders", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Microsoft.Data.OData.Sample.Services.Order), "Order_Details", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Order_Detail), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Order_Details_Products", "Products", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Microsoft.Data.OData.Sample.Services.Product), "Order_Details", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Order_Detail), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Orders_Shippers", "Shippers", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Microsoft.Data.OData.Sample.Services.Shipper), "Orders", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Order), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Products_Suppliers", "Suppliers", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Microsoft.Data.OData.Sample.Services.Supplier), "Products", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Product), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "FK_Territories_Region", "Region", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Microsoft.Data.OData.Sample.Services.Region), "Territories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Territory), true)]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "CustomerCustomerDemo", "CustomerDemographics", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.CustomerDemographic), "Customers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Customer))]
[assembly: EdmRelationshipAttribute("NORTHWNDModel", "EmployeeTerritories", "Employees", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Employee), "Territories", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Microsoft.Data.OData.Sample.Services.Territory))]

#endregion

namespace Microsoft.Data.OData.Sample.Services
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class NORTHWNDEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new NORTHWNDEntities object using the connection string found in the 'NORTHWNDEntities' section of the application configuration file.
        /// </summary>
        public NORTHWNDEntities() : base("name=NORTHWNDEntities", "NORTHWNDEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NORTHWNDEntities object.
        /// </summary>
        public NORTHWNDEntities(string connectionString) : base(connectionString, "NORTHWNDEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NORTHWNDEntities object.
        /// </summary>
        public NORTHWNDEntities(EntityConnection connection) : base(connection, "NORTHWNDEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Category> Categories
        {
            get
            {
                if ((_Categories == null))
                {
                    _Categories = base.CreateObjectSet<Category>("Categories");
                }
                return _Categories;
            }
        }
        private ObjectSet<Category> _Categories;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CustomerDemographic> CustomerDemographics
        {
            get
            {
                if ((_CustomerDemographics == null))
                {
                    _CustomerDemographics = base.CreateObjectSet<CustomerDemographic>("CustomerDemographics");
                }
                return _CustomerDemographics;
            }
        }
        private ObjectSet<CustomerDemographic> _CustomerDemographics;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Customer> Customers
        {
            get
            {
                if ((_Customers == null))
                {
                    _Customers = base.CreateObjectSet<Customer>("Customers");
                }
                return _Customers;
            }
        }
        private ObjectSet<Customer> _Customers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Employee> Employees
        {
            get
            {
                if ((_Employees == null))
                {
                    _Employees = base.CreateObjectSet<Employee>("Employees");
                }
                return _Employees;
            }
        }
        private ObjectSet<Employee> _Employees;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Order_Detail> Order_Details
        {
            get
            {
                if ((_Order_Details == null))
                {
                    _Order_Details = base.CreateObjectSet<Order_Detail>("Order_Details");
                }
                return _Order_Details;
            }
        }
        private ObjectSet<Order_Detail> _Order_Details;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Order> Orders
        {
            get
            {
                if ((_Orders == null))
                {
                    _Orders = base.CreateObjectSet<Order>("Orders");
                }
                return _Orders;
            }
        }
        private ObjectSet<Order> _Orders;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Product> Products
        {
            get
            {
                if ((_Products == null))
                {
                    _Products = base.CreateObjectSet<Product>("Products");
                }
                return _Products;
            }
        }
        private ObjectSet<Product> _Products;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Region> Regions
        {
            get
            {
                if ((_Regions == null))
                {
                    _Regions = base.CreateObjectSet<Region>("Regions");
                }
                return _Regions;
            }
        }
        private ObjectSet<Region> _Regions;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Shipper> Shippers
        {
            get
            {
                if ((_Shippers == null))
                {
                    _Shippers = base.CreateObjectSet<Shipper>("Shippers");
                }
                return _Shippers;
            }
        }
        private ObjectSet<Shipper> _Shippers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Supplier> Suppliers
        {
            get
            {
                if ((_Suppliers == null))
                {
                    _Suppliers = base.CreateObjectSet<Supplier>("Suppliers");
                }
                return _Suppliers;
            }
        }
        private ObjectSet<Supplier> _Suppliers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Territory> Territories
        {
            get
            {
                if ((_Territories == null))
                {
                    _Territories = base.CreateObjectSet<Territory>("Territories");
                }
                return _Territories;
            }
        }
        private ObjectSet<Territory> _Territories;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Categories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCategories(Category category)
        {
            base.AddObject("Categories", category);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CustomerDemographics EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCustomerDemographics(CustomerDemographic customerDemographic)
        {
            base.AddObject("CustomerDemographics", customerDemographic);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Customers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCustomers(Customer customer)
        {
            base.AddObject("Customers", customer);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Employees EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEmployees(Employee employee)
        {
            base.AddObject("Employees", employee);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Order_Details EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOrder_Details(Order_Detail order_Detail)
        {
            base.AddObject("Order_Details", order_Detail);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Orders EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Products EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToProducts(Product product)
        {
            base.AddObject("Products", product);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Regions EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRegions(Region region)
        {
            base.AddObject("Regions", region);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Shippers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToShippers(Shipper shipper)
        {
            base.AddObject("Shippers", shipper);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Suppliers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSuppliers(Supplier supplier)
        {
            base.AddObject("Suppliers", supplier);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Territories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTerritories(Territory territory)
        {
            base.AddObject("Territories", territory);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Category")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Category : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Category object.
        /// </summary>
        /// <param name="categoryID">Initial value of the CategoryID property.</param>
        /// <param name="categoryName">Initial value of the CategoryName property.</param>
        public static Category CreateCategory(global::System.Int32 categoryID, global::System.String categoryName)
        {
            Category category = new Category();
            category.CategoryID = categoryID;
            category.CategoryName = categoryName;
            return category;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                if (_CategoryID != value)
                {
                    OnCategoryIDChanging(value);
                    ReportPropertyChanging("CategoryID");
                    _CategoryID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CategoryID");
                    OnCategoryIDChanged();
                }
            }
        }
        private global::System.Int32 _CategoryID;
        partial void OnCategoryIDChanging(global::System.Int32 value);
        partial void OnCategoryIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {
                OnCategoryNameChanging(value);
                ReportPropertyChanging("CategoryName");
                _CategoryName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CategoryName");
                OnCategoryNameChanged();
            }
        }
        private global::System.String _CategoryName;
        partial void OnCategoryNameChanging(global::System.String value);
        partial void OnCategoryNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] Picture
        {
            get
            {
                return StructuralObject.GetValidValue(_Picture);
            }
            set
            {
                OnPictureChanging(value);
                ReportPropertyChanging("Picture");
                _Picture = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Picture");
                OnPictureChanged();
            }
        }
        private global::System.Byte[] _Picture;
        partial void OnPictureChanging(global::System.Byte[] value);
        partial void OnPictureChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Products_Categories", "Products")]
        public EntityCollection<Product> Products
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Product>("NORTHWNDModel.FK_Products_Categories", "Products");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Product>("NORTHWNDModel.FK_Products_Categories", "Products", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Customer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Customer : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Customer object.
        /// </summary>
        /// <param name="customerID">Initial value of the CustomerID property.</param>
        /// <param name="companyName">Initial value of the CompanyName property.</param>
        public static Customer CreateCustomer(global::System.String customerID, global::System.String companyName)
        {
            Customer customer = new Customer();
            customer.CustomerID = customerID;
            customer.CompanyName = companyName;
            return customer;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                if (_CustomerID != value)
                {
                    OnCustomerIDChanging(value);
                    ReportPropertyChanging("CustomerID");
                    _CustomerID = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("CustomerID");
                    OnCustomerIDChanged();
                }
            }
        }
        private global::System.String _CustomerID;
        partial void OnCustomerIDChanging(global::System.String value);
        partial void OnCustomerIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                OnCompanyNameChanging(value);
                ReportPropertyChanging("CompanyName");
                _CompanyName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CompanyName");
                OnCompanyNameChanged();
            }
        }
        private global::System.String _CompanyName;
        partial void OnCompanyNameChanging(global::System.String value);
        partial void OnCompanyNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ContactName
        {
            get
            {
                return _ContactName;
            }
            set
            {
                OnContactNameChanging(value);
                ReportPropertyChanging("ContactName");
                _ContactName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ContactName");
                OnContactNameChanged();
            }
        }
        private global::System.String _ContactName;
        partial void OnContactNameChanging(global::System.String value);
        partial void OnContactNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ContactTitle
        {
            get
            {
                return _ContactTitle;
            }
            set
            {
                OnContactTitleChanging(value);
                ReportPropertyChanging("ContactTitle");
                _ContactTitle = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ContactTitle");
                OnContactTitleChanged();
            }
        }
        private global::System.String _ContactTitle;
        partial void OnContactTitleChanging(global::System.String value);
        partial void OnContactTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String City
        {
            get
            {
                return _City;
            }
            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }
        private global::System.String _City;
        partial void OnCityChanging(global::System.String value);
        partial void OnCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region
        {
            get
            {
                return _Region;
            }
            set
            {
                OnRegionChanging(value);
                ReportPropertyChanging("Region");
                _Region = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region");
                OnRegionChanged();
            }
        }
        private global::System.String _Region;
        partial void OnRegionChanging(global::System.String value);
        partial void OnRegionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                OnPostalCodeChanging(value);
                ReportPropertyChanging("PostalCode");
                _PostalCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PostalCode");
                OnPostalCodeChanged();
            }
        }
        private global::System.String _PostalCode;
        partial void OnPostalCodeChanging(global::System.String value);
        partial void OnPostalCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }
        private global::System.String _Country;
        partial void OnCountryChanging(global::System.String value);
        partial void OnCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                OnPhoneChanging(value);
                ReportPropertyChanging("Phone");
                _Phone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Phone");
                OnPhoneChanged();
            }
        }
        private global::System.String _Phone;
        partial void OnPhoneChanging(global::System.String value);
        partial void OnPhoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                OnFaxChanging(value);
                ReportPropertyChanging("Fax");
                _Fax = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Fax");
                OnFaxChanged();
            }
        }
        private global::System.String _Fax;
        partial void OnFaxChanging(global::System.String value);
        partial void OnFaxChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Orders_Customers", "Orders")]
        public EntityCollection<Order> Orders
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Order>("NORTHWNDModel.FK_Orders_Customers", "Orders");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Order>("NORTHWNDModel.FK_Orders_Customers", "Orders", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "CustomerCustomerDemo", "CustomerDemographics")]
        public EntityCollection<CustomerDemographic> CustomerDemographics
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<CustomerDemographic>("NORTHWNDModel.CustomerCustomerDemo", "CustomerDemographics");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<CustomerDemographic>("NORTHWNDModel.CustomerCustomerDemo", "CustomerDemographics", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="CustomerDemographic")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CustomerDemographic : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CustomerDemographic object.
        /// </summary>
        /// <param name="customerTypeID">Initial value of the CustomerTypeID property.</param>
        public static CustomerDemographic CreateCustomerDemographic(global::System.String customerTypeID)
        {
            CustomerDemographic customerDemographic = new CustomerDemographic();
            customerDemographic.CustomerTypeID = customerTypeID;
            return customerDemographic;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CustomerTypeID
        {
            get
            {
                return _CustomerTypeID;
            }
            set
            {
                if (_CustomerTypeID != value)
                {
                    OnCustomerTypeIDChanging(value);
                    ReportPropertyChanging("CustomerTypeID");
                    _CustomerTypeID = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("CustomerTypeID");
                    OnCustomerTypeIDChanged();
                }
            }
        }
        private global::System.String _CustomerTypeID;
        partial void OnCustomerTypeIDChanging(global::System.String value);
        partial void OnCustomerTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CustomerDesc
        {
            get
            {
                return _CustomerDesc;
            }
            set
            {
                OnCustomerDescChanging(value);
                ReportPropertyChanging("CustomerDesc");
                _CustomerDesc = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CustomerDesc");
                OnCustomerDescChanged();
            }
        }
        private global::System.String _CustomerDesc;
        partial void OnCustomerDescChanging(global::System.String value);
        partial void OnCustomerDescChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "CustomerCustomerDemo", "Customers")]
        public EntityCollection<Customer> Customers
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Customer>("NORTHWNDModel.CustomerCustomerDemo", "Customers");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Customer>("NORTHWNDModel.CustomerCustomerDemo", "Customers", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Employee")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Employee : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Employee object.
        /// </summary>
        /// <param name="employeeID">Initial value of the EmployeeID property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        public static Employee CreateEmployee(global::System.Int32 employeeID, global::System.String lastName, global::System.String firstName)
        {
            Employee employee = new Employee();
            employee.EmployeeID = employeeID;
            employee.LastName = lastName;
            employee.FirstName = firstName;
            return employee;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                if (_EmployeeID != value)
                {
                    OnEmployeeIDChanging(value);
                    ReportPropertyChanging("EmployeeID");
                    _EmployeeID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EmployeeID");
                    OnEmployeeIDChanged();
                }
            }
        }
        private global::System.Int32 _EmployeeID;
        partial void OnEmployeeIDChanging(global::System.Int32 value);
        partial void OnEmployeeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TitleOfCourtesy
        {
            get
            {
                return _TitleOfCourtesy;
            }
            set
            {
                OnTitleOfCourtesyChanging(value);
                ReportPropertyChanging("TitleOfCourtesy");
                _TitleOfCourtesy = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TitleOfCourtesy");
                OnTitleOfCourtesyChanged();
            }
        }
        private global::System.String _TitleOfCourtesy;
        partial void OnTitleOfCourtesyChanging(global::System.String value);
        partial void OnTitleOfCourtesyChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                OnBirthDateChanging(value);
                ReportPropertyChanging("BirthDate");
                _BirthDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BirthDate");
                OnBirthDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _BirthDate;
        partial void OnBirthDateChanging(Nullable<global::System.DateTime> value);
        partial void OnBirthDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> HireDate
        {
            get
            {
                return _HireDate;
            }
            set
            {
                OnHireDateChanging(value);
                ReportPropertyChanging("HireDate");
                _HireDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("HireDate");
                OnHireDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _HireDate;
        partial void OnHireDateChanging(Nullable<global::System.DateTime> value);
        partial void OnHireDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String City
        {
            get
            {
                return _City;
            }
            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }
        private global::System.String _City;
        partial void OnCityChanging(global::System.String value);
        partial void OnCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region
        {
            get
            {
                return _Region;
            }
            set
            {
                OnRegionChanging(value);
                ReportPropertyChanging("Region");
                _Region = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region");
                OnRegionChanged();
            }
        }
        private global::System.String _Region;
        partial void OnRegionChanging(global::System.String value);
        partial void OnRegionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                OnPostalCodeChanging(value);
                ReportPropertyChanging("PostalCode");
                _PostalCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PostalCode");
                OnPostalCodeChanged();
            }
        }
        private global::System.String _PostalCode;
        partial void OnPostalCodeChanging(global::System.String value);
        partial void OnPostalCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }
        private global::System.String _Country;
        partial void OnCountryChanging(global::System.String value);
        partial void OnCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HomePhone
        {
            get
            {
                return _HomePhone;
            }
            set
            {
                OnHomePhoneChanging(value);
                ReportPropertyChanging("HomePhone");
                _HomePhone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HomePhone");
                OnHomePhoneChanged();
            }
        }
        private global::System.String _HomePhone;
        partial void OnHomePhoneChanging(global::System.String value);
        partial void OnHomePhoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Extension
        {
            get
            {
                return _Extension;
            }
            set
            {
                OnExtensionChanging(value);
                ReportPropertyChanging("Extension");
                _Extension = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Extension");
                OnExtensionChanged();
            }
        }
        private global::System.String _Extension;
        partial void OnExtensionChanging(global::System.String value);
        partial void OnExtensionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] Photo
        {
            get
            {
                return StructuralObject.GetValidValue(_Photo);
            }
            set
            {
                OnPhotoChanging(value);
                ReportPropertyChanging("Photo");
                _Photo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Photo");
                OnPhotoChanged();
            }
        }
        private global::System.Byte[] _Photo;
        partial void OnPhotoChanging(global::System.Byte[] value);
        partial void OnPhotoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                OnNotesChanging(value);
                ReportPropertyChanging("Notes");
                _Notes = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Notes");
                OnNotesChanged();
            }
        }
        private global::System.String _Notes;
        partial void OnNotesChanging(global::System.String value);
        partial void OnNotesChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ReportsTo
        {
            get
            {
                return _ReportsTo;
            }
            set
            {
                OnReportsToChanging(value);
                ReportPropertyChanging("ReportsTo");
                _ReportsTo = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ReportsTo");
                OnReportsToChanged();
            }
        }
        private Nullable<global::System.Int32> _ReportsTo;
        partial void OnReportsToChanging(Nullable<global::System.Int32> value);
        partial void OnReportsToChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PhotoPath
        {
            get
            {
                return _PhotoPath;
            }
            set
            {
                OnPhotoPathChanging(value);
                ReportPropertyChanging("PhotoPath");
                _PhotoPath = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PhotoPath");
                OnPhotoPathChanged();
            }
        }
        private global::System.String _PhotoPath;
        partial void OnPhotoPathChanging(global::System.String value);
        partial void OnPhotoPathChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Employees_Employees", "Employees1")]
        public EntityCollection<Employee> Employees1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("NORTHWNDModel.FK_Employees_Employees", "Employees1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("NORTHWNDModel.FK_Employees_Employees", "Employees1", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Employees_Employees", "Employees")]
        public Employee Employee1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("NORTHWNDModel.FK_Employees_Employees", "Employees").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("NORTHWNDModel.FK_Employees_Employees", "Employees").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> Employee1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("NORTHWNDModel.FK_Employees_Employees", "Employees");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("NORTHWNDModel.FK_Employees_Employees", "Employees", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Orders_Employees", "Orders")]
        public EntityCollection<Order> Orders
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Order>("NORTHWNDModel.FK_Orders_Employees", "Orders");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Order>("NORTHWNDModel.FK_Orders_Employees", "Orders", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "EmployeeTerritories", "Territories")]
        public EntityCollection<Territory> Territories
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Territory>("NORTHWNDModel.EmployeeTerritories", "Territories");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Territory>("NORTHWNDModel.EmployeeTerritories", "Territories", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Order")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Order object.
        /// </summary>
        /// <param name="orderID">Initial value of the OrderID property.</param>
        public static Order CreateOrder(global::System.Int32 orderID)
        {
            Order order = new Order();
            order.OrderID = orderID;
            return order;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                if (_OrderID != value)
                {
                    OnOrderIDChanging(value);
                    ReportPropertyChanging("OrderID");
                    _OrderID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("OrderID");
                    OnOrderIDChanged();
                }
            }
        }
        private global::System.Int32 _OrderID;
        partial void OnOrderIDChanging(global::System.Int32 value);
        partial void OnOrderIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                OnCustomerIDChanging(value);
                ReportPropertyChanging("CustomerID");
                _CustomerID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CustomerID");
                OnCustomerIDChanged();
            }
        }
        private global::System.String _CustomerID;
        partial void OnCustomerIDChanging(global::System.String value);
        partial void OnCustomerIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                OnEmployeeIDChanging(value);
                ReportPropertyChanging("EmployeeID");
                _EmployeeID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("EmployeeID");
                OnEmployeeIDChanged();
            }
        }
        private Nullable<global::System.Int32> _EmployeeID;
        partial void OnEmployeeIDChanging(Nullable<global::System.Int32> value);
        partial void OnEmployeeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                OnOrderDateChanging(value);
                ReportPropertyChanging("OrderDate");
                _OrderDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OrderDate");
                OnOrderDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _OrderDate;
        partial void OnOrderDateChanging(Nullable<global::System.DateTime> value);
        partial void OnOrderDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> RequiredDate
        {
            get
            {
                return _RequiredDate;
            }
            set
            {
                OnRequiredDateChanging(value);
                ReportPropertyChanging("RequiredDate");
                _RequiredDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RequiredDate");
                OnRequiredDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _RequiredDate;
        partial void OnRequiredDateChanging(Nullable<global::System.DateTime> value);
        partial void OnRequiredDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return _ShippedDate;
            }
            set
            {
                OnShippedDateChanging(value);
                ReportPropertyChanging("ShippedDate");
                _ShippedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShippedDate");
                OnShippedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ShipVia
        {
            get
            {
                return _ShipVia;
            }
            set
            {
                OnShipViaChanging(value);
                ReportPropertyChanging("ShipVia");
                _ShipVia = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ShipVia");
                OnShipViaChanged();
            }
        }
        private Nullable<global::System.Int32> _ShipVia;
        partial void OnShipViaChanging(Nullable<global::System.Int32> value);
        partial void OnShipViaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Freight
        {
            get
            {
                return _Freight;
            }
            set
            {
                OnFreightChanging(value);
                ReportPropertyChanging("Freight");
                _Freight = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Freight");
                OnFreightChanged();
            }
        }
        private Nullable<global::System.Decimal> _Freight;
        partial void OnFreightChanging(Nullable<global::System.Decimal> value);
        partial void OnFreightChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipName
        {
            get
            {
                return _ShipName;
            }
            set
            {
                OnShipNameChanging(value);
                ReportPropertyChanging("ShipName");
                _ShipName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipName");
                OnShipNameChanged();
            }
        }
        private global::System.String _ShipName;
        partial void OnShipNameChanging(global::System.String value);
        partial void OnShipNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipAddress
        {
            get
            {
                return _ShipAddress;
            }
            set
            {
                OnShipAddressChanging(value);
                ReportPropertyChanging("ShipAddress");
                _ShipAddress = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipAddress");
                OnShipAddressChanged();
            }
        }
        private global::System.String _ShipAddress;
        partial void OnShipAddressChanging(global::System.String value);
        partial void OnShipAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipCity
        {
            get
            {
                return _ShipCity;
            }
            set
            {
                OnShipCityChanging(value);
                ReportPropertyChanging("ShipCity");
                _ShipCity = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipCity");
                OnShipCityChanged();
            }
        }
        private global::System.String _ShipCity;
        partial void OnShipCityChanging(global::System.String value);
        partial void OnShipCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipRegion
        {
            get
            {
                return _ShipRegion;
            }
            set
            {
                OnShipRegionChanging(value);
                ReportPropertyChanging("ShipRegion");
                _ShipRegion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipRegion");
                OnShipRegionChanged();
            }
        }
        private global::System.String _ShipRegion;
        partial void OnShipRegionChanging(global::System.String value);
        partial void OnShipRegionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipPostalCode
        {
            get
            {
                return _ShipPostalCode;
            }
            set
            {
                OnShipPostalCodeChanging(value);
                ReportPropertyChanging("ShipPostalCode");
                _ShipPostalCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipPostalCode");
                OnShipPostalCodeChanged();
            }
        }
        private global::System.String _ShipPostalCode;
        partial void OnShipPostalCodeChanging(global::System.String value);
        partial void OnShipPostalCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShipCountry
        {
            get
            {
                return _ShipCountry;
            }
            set
            {
                OnShipCountryChanging(value);
                ReportPropertyChanging("ShipCountry");
                _ShipCountry = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShipCountry");
                OnShipCountryChanged();
            }
        }
        private global::System.String _ShipCountry;
        partial void OnShipCountryChanging(global::System.String value);
        partial void OnShipCountryChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Orders_Customers", "Customers")]
        public Customer Customer
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("NORTHWNDModel.FK_Orders_Customers", "Customers").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("NORTHWNDModel.FK_Orders_Customers", "Customers").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Customer> CustomerReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("NORTHWNDModel.FK_Orders_Customers", "Customers");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Customer>("NORTHWNDModel.FK_Orders_Customers", "Customers", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Orders_Employees", "Employees")]
        public Employee Employee
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("NORTHWNDModel.FK_Orders_Employees", "Employees").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("NORTHWNDModel.FK_Orders_Employees", "Employees").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> EmployeeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("NORTHWNDModel.FK_Orders_Employees", "Employees");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("NORTHWNDModel.FK_Orders_Employees", "Employees", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Order_Details_Orders", "Order_Details")]
        public EntityCollection<Order_Detail> Order_Details
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Order_Detail>("NORTHWNDModel.FK_Order_Details_Orders", "Order_Details");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Order_Detail>("NORTHWNDModel.FK_Order_Details_Orders", "Order_Details", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Orders_Shippers", "Shippers")]
        public Shipper Shipper
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Shipper>("NORTHWNDModel.FK_Orders_Shippers", "Shippers").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Shipper>("NORTHWNDModel.FK_Orders_Shippers", "Shippers").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Shipper> ShipperReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Shipper>("NORTHWNDModel.FK_Orders_Shippers", "Shippers");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Shipper>("NORTHWNDModel.FK_Orders_Shippers", "Shippers", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Order_Detail")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order_Detail : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Order_Detail object.
        /// </summary>
        /// <param name="orderID">Initial value of the OrderID property.</param>
        /// <param name="productID">Initial value of the ProductID property.</param>
        /// <param name="unitPrice">Initial value of the UnitPrice property.</param>
        /// <param name="quantity">Initial value of the Quantity property.</param>
        /// <param name="discount">Initial value of the Discount property.</param>
        public static Order_Detail CreateOrder_Detail(global::System.Int32 orderID, global::System.Int32 productID, global::System.Decimal unitPrice, global::System.Int16 quantity, global::System.Single discount)
        {
            Order_Detail order_Detail = new Order_Detail();
            order_Detail.OrderID = orderID;
            order_Detail.ProductID = productID;
            order_Detail.UnitPrice = unitPrice;
            order_Detail.Quantity = quantity;
            order_Detail.Discount = discount;
            return order_Detail;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                if (_OrderID != value)
                {
                    OnOrderIDChanging(value);
                    ReportPropertyChanging("OrderID");
                    _OrderID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("OrderID");
                    OnOrderIDChanged();
                }
            }
        }
        private global::System.Int32 _OrderID;
        partial void OnOrderIDChanging(global::System.Int32 value);
        partial void OnOrderIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                if (_ProductID != value)
                {
                    OnProductIDChanging(value);
                    ReportPropertyChanging("ProductID");
                    _ProductID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ProductID");
                    OnProductIDChanged();
                }
            }
        }
        private global::System.Int32 _ProductID;
        partial void OnProductIDChanging(global::System.Int32 value);
        partial void OnProductIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                OnUnitPriceChanging(value);
                ReportPropertyChanging("UnitPrice");
                _UnitPrice = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UnitPrice");
                OnUnitPriceChanged();
            }
        }
        private global::System.Decimal _UnitPrice;
        partial void OnUnitPriceChanging(global::System.Decimal value);
        partial void OnUnitPriceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                OnQuantityChanging(value);
                ReportPropertyChanging("Quantity");
                _Quantity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Quantity");
                OnQuantityChanged();
            }
        }
        private global::System.Int16 _Quantity;
        partial void OnQuantityChanging(global::System.Int16 value);
        partial void OnQuantityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Single Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                OnDiscountChanging(value);
                ReportPropertyChanging("Discount");
                _Discount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Discount");
                OnDiscountChanged();
            }
        }
        private global::System.Single _Discount;
        partial void OnDiscountChanging(global::System.Single value);
        partial void OnDiscountChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Order_Details_Orders", "Orders")]
        public Order Order
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("NORTHWNDModel.FK_Order_Details_Orders", "Orders").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("NORTHWNDModel.FK_Order_Details_Orders", "Orders").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Order> OrderReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("NORTHWNDModel.FK_Order_Details_Orders", "Orders");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Order>("NORTHWNDModel.FK_Order_Details_Orders", "Orders", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Order_Details_Products", "Products")]
        public Product Product
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("NORTHWNDModel.FK_Order_Details_Products", "Products").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("NORTHWNDModel.FK_Order_Details_Products", "Products").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Product> ProductReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("NORTHWNDModel.FK_Order_Details_Products", "Products");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Product>("NORTHWNDModel.FK_Order_Details_Products", "Products", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Product")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Product : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Product object.
        /// </summary>
        /// <param name="productID">Initial value of the ProductID property.</param>
        /// <param name="productName">Initial value of the ProductName property.</param>
        /// <param name="discontinued">Initial value of the Discontinued property.</param>
        public static Product CreateProduct(global::System.Int32 productID, global::System.String productName, global::System.Boolean discontinued)
        {
            Product product = new Product();
            product.ProductID = productID;
            product.ProductName = productName;
            product.Discontinued = discontinued;
            return product;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                if (_ProductID != value)
                {
                    OnProductIDChanging(value);
                    ReportPropertyChanging("ProductID");
                    _ProductID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ProductID");
                    OnProductIDChanged();
                }
            }
        }
        private global::System.Int32 _ProductID;
        partial void OnProductIDChanging(global::System.Int32 value);
        partial void OnProductIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                OnProductNameChanging(value);
                ReportPropertyChanging("ProductName");
                _ProductName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ProductName");
                OnProductNameChanged();
            }
        }
        private global::System.String _ProductName;
        partial void OnProductNameChanging(global::System.String value);
        partial void OnProductNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                OnSupplierIDChanging(value);
                ReportPropertyChanging("SupplierID");
                _SupplierID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SupplierID");
                OnSupplierIDChanged();
            }
        }
        private Nullable<global::System.Int32> _SupplierID;
        partial void OnSupplierIDChanging(Nullable<global::System.Int32> value);
        partial void OnSupplierIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                OnCategoryIDChanging(value);
                ReportPropertyChanging("CategoryID");
                _CategoryID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CategoryID");
                OnCategoryIDChanged();
            }
        }
        private Nullable<global::System.Int32> _CategoryID;
        partial void OnCategoryIDChanging(Nullable<global::System.Int32> value);
        partial void OnCategoryIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String QuantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                OnQuantityPerUnitChanging(value);
                ReportPropertyChanging("QuantityPerUnit");
                _QuantityPerUnit = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("QuantityPerUnit");
                OnQuantityPerUnitChanged();
            }
        }
        private global::System.String _QuantityPerUnit;
        partial void OnQuantityPerUnitChanging(global::System.String value);
        partial void OnQuantityPerUnitChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                OnUnitPriceChanging(value);
                ReportPropertyChanging("UnitPrice");
                _UnitPrice = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UnitPrice");
                OnUnitPriceChanged();
            }
        }
        private Nullable<global::System.Decimal> _UnitPrice;
        partial void OnUnitPriceChanging(Nullable<global::System.Decimal> value);
        partial void OnUnitPriceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> UnitsInStock
        {
            get
            {
                return _UnitsInStock;
            }
            set
            {
                OnUnitsInStockChanging(value);
                ReportPropertyChanging("UnitsInStock");
                _UnitsInStock = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UnitsInStock");
                OnUnitsInStockChanged();
            }
        }
        private Nullable<global::System.Int16> _UnitsInStock;
        partial void OnUnitsInStockChanging(Nullable<global::System.Int16> value);
        partial void OnUnitsInStockChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> UnitsOnOrder
        {
            get
            {
                return _UnitsOnOrder;
            }
            set
            {
                OnUnitsOnOrderChanging(value);
                ReportPropertyChanging("UnitsOnOrder");
                _UnitsOnOrder = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UnitsOnOrder");
                OnUnitsOnOrderChanged();
            }
        }
        private Nullable<global::System.Int16> _UnitsOnOrder;
        partial void OnUnitsOnOrderChanging(Nullable<global::System.Int16> value);
        partial void OnUnitsOnOrderChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> ReorderLevel
        {
            get
            {
                return _ReorderLevel;
            }
            set
            {
                OnReorderLevelChanging(value);
                ReportPropertyChanging("ReorderLevel");
                _ReorderLevel = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ReorderLevel");
                OnReorderLevelChanged();
            }
        }
        private Nullable<global::System.Int16> _ReorderLevel;
        partial void OnReorderLevelChanging(Nullable<global::System.Int16> value);
        partial void OnReorderLevelChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Discontinued
        {
            get
            {
                return _Discontinued;
            }
            set
            {
                OnDiscontinuedChanging(value);
                ReportPropertyChanging("Discontinued");
                _Discontinued = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Discontinued");
                OnDiscontinuedChanged();
            }
        }
        private global::System.Boolean _Discontinued;
        partial void OnDiscontinuedChanging(global::System.Boolean value);
        partial void OnDiscontinuedChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Products_Categories", "Categories")]
        public Category Category
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Category>("NORTHWNDModel.FK_Products_Categories", "Categories").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Category>("NORTHWNDModel.FK_Products_Categories", "Categories").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Category> CategoryReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Category>("NORTHWNDModel.FK_Products_Categories", "Categories");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Category>("NORTHWNDModel.FK_Products_Categories", "Categories", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Order_Details_Products", "Order_Details")]
        public EntityCollection<Order_Detail> Order_Details
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Order_Detail>("NORTHWNDModel.FK_Order_Details_Products", "Order_Details");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Order_Detail>("NORTHWNDModel.FK_Order_Details_Products", "Order_Details", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Products_Suppliers", "Suppliers")]
        public Supplier Supplier
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Supplier>("NORTHWNDModel.FK_Products_Suppliers", "Suppliers").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Supplier>("NORTHWNDModel.FK_Products_Suppliers", "Suppliers").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Supplier> SupplierReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Supplier>("NORTHWNDModel.FK_Products_Suppliers", "Suppliers");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Supplier>("NORTHWNDModel.FK_Products_Suppliers", "Suppliers", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Region")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Region : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Region object.
        /// </summary>
        /// <param name="regionID">Initial value of the RegionID property.</param>
        /// <param name="regionDescription">Initial value of the RegionDescription property.</param>
        public static Region CreateRegion(global::System.Int32 regionID, global::System.String regionDescription)
        {
            Region region = new Region();
            region.RegionID = regionID;
            region.RegionDescription = regionDescription;
            return region;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 RegionID
        {
            get
            {
                return _RegionID;
            }
            set
            {
                if (_RegionID != value)
                {
                    OnRegionIDChanging(value);
                    ReportPropertyChanging("RegionID");
                    _RegionID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("RegionID");
                    OnRegionIDChanged();
                }
            }
        }
        private global::System.Int32 _RegionID;
        partial void OnRegionIDChanging(global::System.Int32 value);
        partial void OnRegionIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String RegionDescription
        {
            get
            {
                return _RegionDescription;
            }
            set
            {
                OnRegionDescriptionChanging(value);
                ReportPropertyChanging("RegionDescription");
                _RegionDescription = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("RegionDescription");
                OnRegionDescriptionChanged();
            }
        }
        private global::System.String _RegionDescription;
        partial void OnRegionDescriptionChanging(global::System.String value);
        partial void OnRegionDescriptionChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Territories_Region", "Territories")]
        public EntityCollection<Territory> Territories
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Territory>("NORTHWNDModel.FK_Territories_Region", "Territories");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Territory>("NORTHWNDModel.FK_Territories_Region", "Territories", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Shipper")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Shipper : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Shipper object.
        /// </summary>
        /// <param name="shipperID">Initial value of the ShipperID property.</param>
        /// <param name="companyName">Initial value of the CompanyName property.</param>
        public static Shipper CreateShipper(global::System.Int32 shipperID, global::System.String companyName)
        {
            Shipper shipper = new Shipper();
            shipper.ShipperID = shipperID;
            shipper.CompanyName = companyName;
            return shipper;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ShipperID
        {
            get
            {
                return _ShipperID;
            }
            set
            {
                if (_ShipperID != value)
                {
                    OnShipperIDChanging(value);
                    ReportPropertyChanging("ShipperID");
                    _ShipperID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ShipperID");
                    OnShipperIDChanged();
                }
            }
        }
        private global::System.Int32 _ShipperID;
        partial void OnShipperIDChanging(global::System.Int32 value);
        partial void OnShipperIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                OnCompanyNameChanging(value);
                ReportPropertyChanging("CompanyName");
                _CompanyName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CompanyName");
                OnCompanyNameChanged();
            }
        }
        private global::System.String _CompanyName;
        partial void OnCompanyNameChanging(global::System.String value);
        partial void OnCompanyNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                OnPhoneChanging(value);
                ReportPropertyChanging("Phone");
                _Phone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Phone");
                OnPhoneChanged();
            }
        }
        private global::System.String _Phone;
        partial void OnPhoneChanging(global::System.String value);
        partial void OnPhoneChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Orders_Shippers", "Orders")]
        public EntityCollection<Order> Orders
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Order>("NORTHWNDModel.FK_Orders_Shippers", "Orders");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Order>("NORTHWNDModel.FK_Orders_Shippers", "Orders", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Supplier")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Supplier : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Supplier object.
        /// </summary>
        /// <param name="supplierID">Initial value of the SupplierID property.</param>
        /// <param name="companyName">Initial value of the CompanyName property.</param>
        public static Supplier CreateSupplier(global::System.Int32 supplierID, global::System.String companyName)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierID = supplierID;
            supplier.CompanyName = companyName;
            return supplier;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                if (_SupplierID != value)
                {
                    OnSupplierIDChanging(value);
                    ReportPropertyChanging("SupplierID");
                    _SupplierID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("SupplierID");
                    OnSupplierIDChanged();
                }
            }
        }
        private global::System.Int32 _SupplierID;
        partial void OnSupplierIDChanging(global::System.Int32 value);
        partial void OnSupplierIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                OnCompanyNameChanging(value);
                ReportPropertyChanging("CompanyName");
                _CompanyName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CompanyName");
                OnCompanyNameChanged();
            }
        }
        private global::System.String _CompanyName;
        partial void OnCompanyNameChanging(global::System.String value);
        partial void OnCompanyNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ContactName
        {
            get
            {
                return _ContactName;
            }
            set
            {
                OnContactNameChanging(value);
                ReportPropertyChanging("ContactName");
                _ContactName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ContactName");
                OnContactNameChanged();
            }
        }
        private global::System.String _ContactName;
        partial void OnContactNameChanging(global::System.String value);
        partial void OnContactNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ContactTitle
        {
            get
            {
                return _ContactTitle;
            }
            set
            {
                OnContactTitleChanging(value);
                ReportPropertyChanging("ContactTitle");
                _ContactTitle = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ContactTitle");
                OnContactTitleChanged();
            }
        }
        private global::System.String _ContactTitle;
        partial void OnContactTitleChanging(global::System.String value);
        partial void OnContactTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String City
        {
            get
            {
                return _City;
            }
            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }
        private global::System.String _City;
        partial void OnCityChanging(global::System.String value);
        partial void OnCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Region
        {
            get
            {
                return _Region;
            }
            set
            {
                OnRegionChanging(value);
                ReportPropertyChanging("Region");
                _Region = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Region");
                OnRegionChanged();
            }
        }
        private global::System.String _Region;
        partial void OnRegionChanging(global::System.String value);
        partial void OnRegionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                OnPostalCodeChanging(value);
                ReportPropertyChanging("PostalCode");
                _PostalCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PostalCode");
                OnPostalCodeChanged();
            }
        }
        private global::System.String _PostalCode;
        partial void OnPostalCodeChanging(global::System.String value);
        partial void OnPostalCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }
        private global::System.String _Country;
        partial void OnCountryChanging(global::System.String value);
        partial void OnCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                OnPhoneChanging(value);
                ReportPropertyChanging("Phone");
                _Phone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Phone");
                OnPhoneChanged();
            }
        }
        private global::System.String _Phone;
        partial void OnPhoneChanging(global::System.String value);
        partial void OnPhoneChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                OnFaxChanging(value);
                ReportPropertyChanging("Fax");
                _Fax = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Fax");
                OnFaxChanged();
            }
        }
        private global::System.String _Fax;
        partial void OnFaxChanging(global::System.String value);
        partial void OnFaxChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HomePage
        {
            get
            {
                return _HomePage;
            }
            set
            {
                OnHomePageChanging(value);
                ReportPropertyChanging("HomePage");
                _HomePage = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HomePage");
                OnHomePageChanged();
            }
        }
        private global::System.String _HomePage;
        partial void OnHomePageChanging(global::System.String value);
        partial void OnHomePageChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Products_Suppliers", "Products")]
        public EntityCollection<Product> Products
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Product>("NORTHWNDModel.FK_Products_Suppliers", "Products");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Product>("NORTHWNDModel.FK_Products_Suppliers", "Products", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="NORTHWNDModel", Name="Territory")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Territory : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Territory object.
        /// </summary>
        /// <param name="territoryID">Initial value of the TerritoryID property.</param>
        /// <param name="territoryDescription">Initial value of the TerritoryDescription property.</param>
        /// <param name="regionID">Initial value of the RegionID property.</param>
        public static Territory CreateTerritory(global::System.String territoryID, global::System.String territoryDescription, global::System.Int32 regionID)
        {
            Territory territory = new Territory();
            territory.TerritoryID = territoryID;
            territory.TerritoryDescription = territoryDescription;
            territory.RegionID = regionID;
            return territory;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String TerritoryID
        {
            get
            {
                return _TerritoryID;
            }
            set
            {
                if (_TerritoryID != value)
                {
                    OnTerritoryIDChanging(value);
                    ReportPropertyChanging("TerritoryID");
                    _TerritoryID = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("TerritoryID");
                    OnTerritoryIDChanged();
                }
            }
        }
        private global::System.String _TerritoryID;
        partial void OnTerritoryIDChanging(global::System.String value);
        partial void OnTerritoryIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String TerritoryDescription
        {
            get
            {
                return _TerritoryDescription;
            }
            set
            {
                OnTerritoryDescriptionChanging(value);
                ReportPropertyChanging("TerritoryDescription");
                _TerritoryDescription = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("TerritoryDescription");
                OnTerritoryDescriptionChanged();
            }
        }
        private global::System.String _TerritoryDescription;
        partial void OnTerritoryDescriptionChanging(global::System.String value);
        partial void OnTerritoryDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 RegionID
        {
            get
            {
                return _RegionID;
            }
            set
            {
                OnRegionIDChanging(value);
                ReportPropertyChanging("RegionID");
                _RegionID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RegionID");
                OnRegionIDChanged();
            }
        }
        private global::System.Int32 _RegionID;
        partial void OnRegionIDChanging(global::System.Int32 value);
        partial void OnRegionIDChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "FK_Territories_Region", "Region")]
        public Region Region
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Region>("NORTHWNDModel.FK_Territories_Region", "Region").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Region>("NORTHWNDModel.FK_Territories_Region", "Region").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Region> RegionReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Region>("NORTHWNDModel.FK_Territories_Region", "Region");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Region>("NORTHWNDModel.FK_Territories_Region", "Region", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("NORTHWNDModel", "EmployeeTerritories", "Employees")]
        public EntityCollection<Employee> Employees
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("NORTHWNDModel.EmployeeTerritories", "Employees");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("NORTHWNDModel.EmployeeTerritories", "Employees", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
