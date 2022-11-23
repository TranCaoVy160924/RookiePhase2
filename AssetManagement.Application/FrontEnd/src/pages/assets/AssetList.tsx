import React from "react"
import { Datagrid, List, TextField, Toolbar, EditButton } from "react-admin"

export default () => {
   return <List>
      <Datagrid>
         <TextField source="id" />
         <TextField source="name" />
         <TextField source="assetCode" />
         <TextField source="categoryName" />
         <TextField source="state" />
         <EditButton size="small"/>
      </Datagrid>
   </List>
}