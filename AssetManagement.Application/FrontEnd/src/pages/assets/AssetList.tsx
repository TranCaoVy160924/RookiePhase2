import React, { useEffect, useState } from "react";
import {
  Datagrid,
  List,
  Pagination,
  SelectArrayInput,
  TextField,
  TextInput,
  useListContext,
} from "react-admin";
import { CustomDeleteWithConfirmButton } from "../../components/modal/confirmDeleteModal/CustomDeleteWithConfirm";
import HighlightOffIcon from "@mui/icons-material/HighlightOff";
import AssetsPagination from "../../components/pagination/AssetsPagination";
import StateFilterSelect from "../../components/select/StateFilterSelect";
import AssetShow from "./AssetShow";

export default () => {
  const [isOpened, setIsOpened] = useState(false);
  const [record, setRecord] = useState();

  const toggle = () => {
    setIsOpened(!isOpened);
  };

  const postRowClick = (id, resource, record) => {
    setRecord(record);
    toggle();
    return "";
  };

  const assetsFilter = [
    <TextInput label="Search" source="searchString" alwaysOn />,
    // <SelectArrayInput source="states" choices={[
    //     { id: '0', name: 'Available' },
    //     { id: '1', name: 'Not available' },
    //     { id: '2', name: 'Waiting for recycling' },
    //     { id: '3', name: 'Recyled' },
    // ]} />,
    <StateFilterSelect
      source="states"
      statesList={[
        { value: 0, text: "Available" },
        { value: 1, text: "Not Available" },
        { value: 2, text: "Waiting for recycling" },
        { value: 3, text: "Recycled" },
      ]}
    />,
    <SelectArrayInput
      source="types"
      choices={[
        { id: "admin", name: "Admin" },
        { id: "u001", name: "Editor" },
        { id: "u002", name: "Moderator" },
        { id: "u003", name: "Reviewer" },
      ]}
    />,
  ];

  return (
    <>
      <List
        perPage={5}
        pagination={<AssetsPagination />}
        filters={assetsFilter}
        exporter={false}
        sort={{ field: "name", order: "DESC" }}
      >
        <Datagrid
          rowClick={postRowClick}
          empty={
            <p>
              <h2>No Result found</h2>
            </p>
          }
          bulkActionButtons={false}
        >
          <TextField source="id" />
          <TextField source="name" />
          <TextField source="assetCode" />
          <TextField source="categoryName" />
          <TextField source="state" />
          <CustomDeleteWithConfirmButton
            icon={<HighlightOffIcon />}
            confirmTitle="Are you sure?"
            confirmContent="Do you want to delete this asset?"
          />
        </Datagrid>
      </List>
      <AssetShow isOpened={isOpened} toggle={toggle} record={record} />
    </>
  );
};
