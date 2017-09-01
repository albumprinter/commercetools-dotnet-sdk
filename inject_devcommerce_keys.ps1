$json = Get-Content '.\commercetools.Test\appsettings.json' | Out-String | ConvertFrom-Json;
$json.commercetoolsClientID = $env::COMMERCETOOLS_CLIENT_ID;
$json.commercetoolsClientSecret = $env::COMMERCETOOLS_CLIENT_SECRET;
$json | ConvertTo-Json -depth 100 | Set-Content '.\commercetools.Test\appsettings.json';
echo Get-Content '.\commercetools.Test\appsettings.json' | Out-String;