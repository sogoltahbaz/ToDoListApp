# ItemApiCli.Api.ItemsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ItemsAddItemPost**](ItemsApi.md#itemsadditempost) | **POST** /Items/AddItem | 
[**ItemsDeleteitemIdiDelete**](ItemsApi.md#itemsdeleteitemididelete) | **DELETE** /Items/deleteitem/{idi} | 
[**ItemsGet**](ItemsApi.md#itemsget) | **GET** /Items | 
[**ItemsGetItemIdGet**](ItemsApi.md#itemsgetitemidget) | **GET** /Items/getItem/{id} | 


<a name="itemsadditempost"></a>
# **ItemsAddItemPost**
> void ItemsAddItemPost (ToDoItems toDoItems = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ItemApiCli.Api;
using ItemApiCli.Client;
using ItemApiCli.Model;

namespace Example
{
    public class ItemsAddItemPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ItemsApi(config);
            var toDoItems = new ToDoItems(); // ToDoItems |  (optional) 

            try
            {
                apiInstance.ItemsAddItemPost(toDoItems);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsApi.ItemsAddItemPost: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **toDoItems** | [**ToDoItems**](ToDoItems.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="itemsdeleteitemididelete"></a>
# **ItemsDeleteitemIdiDelete**
> void ItemsDeleteitemIdiDelete (string idi)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ItemApiCli.Api;
using ItemApiCli.Client;
using ItemApiCli.Model;

namespace Example
{
    public class ItemsDeleteitemIdiDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ItemsApi(config);
            var idi = "idi_example";  // string | 

            try
            {
                apiInstance.ItemsDeleteitemIdiDelete(idi);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsApi.ItemsDeleteitemIdiDelete: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **idi** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="itemsget"></a>
# **ItemsGet**
> List&lt;ToDoItems&gt; ItemsGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ItemApiCli.Api;
using ItemApiCli.Client;
using ItemApiCli.Model;

namespace Example
{
    public class ItemsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ItemsApi(config);

            try
            {
                List<ToDoItems> result = apiInstance.ItemsGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsApi.ItemsGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List&lt;ToDoItems&gt;**](ToDoItems.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="itemsgetitemidget"></a>
# **ItemsGetItemIdGet**
> ToDoItems ItemsGetItemIdGet (string id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ItemApiCli.Api;
using ItemApiCli.Client;
using ItemApiCli.Model;

namespace Example
{
    public class ItemsGetItemIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ItemsApi(config);
            var id = "id_example";  // string | 

            try
            {
                ToDoItems result = apiInstance.ItemsGetItemIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ItemsApi.ItemsGetItemIdGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**ToDoItems**](ToDoItems.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

