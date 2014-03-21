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
	<add key="comment_uri" value="http://www.blognone.com/crss"/>
  </appSettings>
</configuration>
```

Create new client.
```
var client = new BlognoneClient();
```

Call GetContent method.
```
var channel = client.GetContent();
```

Call GetComment method.
```
var channel = client.GetComment();
```