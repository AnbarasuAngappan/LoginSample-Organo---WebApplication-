<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <system.serviceModel>
        <bindings>
            <basicHttpBinding>
                <binding name="BasicHttpBinding_IReadService" sendTimeout="00:05:00" />
            </basicHttpBinding>
        </bindings>
        <client>
            <endpoint address="http://localhost:50766/ReadService.svc" binding="basicHttpBinding"
                bindingConfiguration="BasicHttpBinding_IReadService" contract="IReadService"
                name="BasicHttpBinding_IReadService" />
        </client>
    </system.serviceModel>
</configuration>


https://www.c-sharpcorner.com/UploadFile/d13d20/creating-aspnet-mvc-app-with-wcf-service-docx/




  <connectionStrings>    
   <add name="DefaultConnection" connectionString="Data Source= IB-ANBARASU\SQLSERVER2017; Integrated Security=true;Initial Catalog= designdb; uid=sa; Password=utl@123; " providerName="System.Data.SqlClient" />
   <add name="designdbEntities" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=IB-ANBARASU\SQLSERVER2017;initial catalog=designdb;integrated security=True;user id=sa;password=utl@123;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>



   <connectionStrings>
    <remove name="LocalSqlServer" />
    <add connectionString="Data Source=WIN-6P1VGEMCAV7\SQLEXPRESS;Initial Catalog= designdb; uid=nuclyodb;Password=devplus@1234;" name="DefaultConnection" providerName="System.Data.SqlClient" />
    <add name="designdbEntities" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=WIN-6P1VGEMCAV7\SQLEXPRESS;initial catalog=designdb;uid=nuclyodb;Password=devplus@1234;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>