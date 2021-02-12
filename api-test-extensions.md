### Hydra Core API Tests Extensions

Thi project provide a vast extension of Asserts that can be applied accross tests in API request and response.

#### How to use it

In your Unit test project, I have to create a map from your API Response and implement the interface ```IRequestResultAssertion```:

##### Example:
```c#
 public class BadRequestObjectResultMap : IRequestResultAssertion
    {
        public int ErrorCode { get; set; }
        public List<string> ErrorMessages { get; set ; }

        public BadRequestObjectResultMap(IActionResult actionResult)
        {
            var badRequestResult = actionResult as BadRequestObjectResult;
            var validationProblemDetails = badRequestResult.Value as ValidationProblemDetails;
            ErrorMessages =  validationProblemDetails.Errors.SelectMany(a => a.Value).ToList();
            ErrorCode = (int)badRequestResult.StatusCode;
        }
    }
```
After creating the ObjectResultMap you can simple call the extension inside your Unit test method.
```c#
var responseAssert = new BadRequestObjectResultMap(response);

var expectedErrors = new List<string>
{
  "Invalid request"
};

responseAssert.IsInvalidRequest(expectedErrors);
```
