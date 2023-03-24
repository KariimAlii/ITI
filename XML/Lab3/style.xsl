<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
    <h2>Employees</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th>Name</th>
        <th>Phone</th>
        <th>Email</th>
      </tr>
      <xsl:for-each select="Contacts/employee">
		  <tr>
			<td><xsl:value-of select="name"/></td>
			<xsl:for-each select="phones">
				<td><xsl:value-of select="phone"/></td>
			</xsl:for-each>
			<td><xsl:value-of select="email"/></td>
		  </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>