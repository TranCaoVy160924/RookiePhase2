import React, { useState } from "react";
import AssetShow from "./AssetShow";
import {
  Datagrid,
  List,
  SelectArrayInput,
  TextField,
  TextInput,
} from "react-admin";

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
    <SelectArrayInput
      source="states"
      choices={[
        { id: "0", name: "Available" },
        { id: "1", name: "Not available" },
        { id: "2", name: "Waiting for recycling" },
        { id: "3", name: "Recyled" },
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
      <List filters={assetsFilter}>
        <Datagrid rowClick={postRowClick}>
          <TextField source="id" />
          <TextField source="name" />
          <TextField source="assetCode" />
          <TextField source="categoryName" />
          <TextField source="state" />
        </Datagrid>
      </List>
      <AssetShow isOpened={isOpened} toggle={toggle} record={record} />
    </>
  );
};
