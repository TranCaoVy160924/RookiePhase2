import React from "react"
import { Datagrid, List, SelectArrayInput, TextField, TextInput, DeleteWithConfirmButton, Toolbar } from "react-admin"
import { CustomDeleteWithConfirmButton } from "../../components/modal/confirmDeleteModal/CustomDeleteWithConfirm";

export default () => {
    const assetsFilter = [
        <TextInput label="Search" source="searchString" alwaysOn />,
        <SelectArrayInput source="states" choices={[
            { id: '0', name: 'Available' },
            { id: '1', name: 'Not available' },
            { id: '2', name: 'Waiting for recycling' },
            { id: '3', name: 'Recyled' },
        ]} />,
        <SelectArrayInput source="types" choices={[
            { id: 'admin', name: 'Admin' },
            { id: 'u001', name: 'Editor' },
            { id: 'u002', name: 'Moderator' },
            { id: 'u003', name: 'Reviewer' },
        ]} />
    ];
    return <List filters={assetsFilter}>
        <Datagrid>
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="assetCode" />
            <TextField source="categoryName" />
            <TextField source="state" />
            <CustomDeleteWithConfirmButton
                confirmTitle="Are you sure?"
                confirmContent="Do you want to delete this asset?"
            />
        </Datagrid>
    </List>
}