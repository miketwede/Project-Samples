Siaqodb "Starter Edition" allows you to use Siaqodb for FREE forever but with a limitation: you may only store up to 100 objects per Type.

If there is no license key provided, Siaqodb will run as "Starter Edition".

To fully test Siaqodb, you can get a Trial license key which allows you to use Siaqodb for 30 days.(check our website for details).
___________________________________________________
Platform considerations:

Siaqodb assemblies are still platform independent, but projects requires platforms specific lmdb binaries. However if you use Nuget packages those binaries will be automatically placed into your /bin folder and no action is required. If you manually reference Siaqodb assemblies on Windows based platforms, be sure you copy also LMDB native binaries for each platform you target.
More info abot this can be found here: http://siaqodb.com/docs/Platform-specifics/

___________________________________________________
Siaqodb 5.0 vs 4.0 considerations:

-Siaqodb 4.0 database files are not seen by Siaqodb 5.0. However we offer a smooth migration path: you can reference the assembly from "bin_BackwardCompatible" folder and using Sqo.SiaqodbUtil.Migrate(...) method Siaqodb 4.X objects will be imported into new Siaqodb 5.0 database( see Examples\SiaqodbMigrate_4to5 project).

-Even the storage engine is changed, the API is 99% the same as Siaqodb 4.X API

-Siaqodb 5.0 uses only one database file called "data.mdb" everything is kept: data, indexes, metadata.

-LMDB storage engine requires to allocate db size up front; Siaqodb sets default size to 50 MB; to increase/decrease this size, use the Open method like this: Sqo.Siaqodb.Open(path,30*1024*1024 ,200);//db size has now 30MB.

-Sqo.Siaqodb class implements now IDisposable since it's using unmanaged code, so Siaqodb must always be closed/disposed to release resources.

-Util methods: Shrink/Reindex/Repair does not make sense anymore, so they are removed.

-StartBulkInsert/EndBulkInsert does not make sense anymore, so they are removed.

___________________________________________________

