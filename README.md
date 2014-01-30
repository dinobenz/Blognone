Blognone
==============

Blognone reader client.

Usage
==============
Configuration feed uri in application setting file.
```
<configuration>
  <appSettings>
    <add key="feed_uri" value="http://www.blognone.com/atom.xml"/>
  </appSettings>
</configuration>
```

Create new client.
```
var client = new BlognoneClient();
```

Call GetFeed method.
```
var channel = client.Get();
```
