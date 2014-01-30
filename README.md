Blognone
==============

Blognone reader client.

Usage
==============
1. Configuration feed uri in application setting file.
```
<configuration>
  <appSettings>
    <add key="feed_uri" value="http://www.blognone.com/atom.xml"/>
  </appSettings>
</configuration>
```

2. Create new client.
```
var client = new BlognoneClient();
```

3. Call GetFeed method.
```
var channel = client.Get();
```