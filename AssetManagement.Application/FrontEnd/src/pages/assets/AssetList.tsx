import React from "react"
import { Datagrid, List, Pagination, SelectArrayInput, TextField, TextInput, EditButton } from "react-admin"
import { CustomDeleteWithConfirmButton } from "../../components/modal/confirmDeleteModal/CustomDeleteWithConfirm";
import HighlightOffIcon from '@mui/icons-material/HighlightOff';
import AssetsPagination from "../../components/pagination/AssetsPagination";
import StateFilterSelect from "../../components/select/StateFilterSelect";
import { ButtonGroup } from "@mui/material";

export default () => {
    const assetsFilter = [
        <TextInput label="Search" source="searchString" alwaysOn />,
        // <SelectArrayInput source="states" choices={[
        //     { id: '0', name: 'Available' },
        //     { id: '1', name: 'Not available' },
        //     { id: '2', name: 'Waiting for recycling' },
        //     { id: '3', name: 'Recyled' },
        // ]} />,
        <StateFilterSelect source="states" statesList={[{ value: 0, text: "Available" }, { value: 1, text: "Not Available" }, { value: 2, text: "Waiting for recycling" }, { value: 3, text: "Recycled" }]} />,
        <SelectArrayInput source="types" choices={[
            { id: 'admin', name: 'Admin' },
            { id: 'u001', name: 'Editor' },
            { id: 'u002', name: 'Moderator' },
            { id: 'u003', name: 'Reviewer' },
        ]} />
    ];
    return <List pagination={<AssetsPagination />} filters={assetsFilter} exporter={false} sort={{ field: 'name', order: 'DESC' }}>
        <Datagrid bulkActionButtons={false}>
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="assetCode" />
            <TextField source="categoryName" />
            <TextField source="state" />
            <ButtonGroup sx={{border: null}}>
                <EditButton variant="text" size="small" label=""/>
                <CustomDeleteWithConfirmButton
                    icon={<HighlightOffIcon />}
                    confirmTitle="Are you sure?"
                    confirmContent="Do you want to delete this asset?"
                    />
                </ButtonGroup>
        </Datagrid>
    </List>
}