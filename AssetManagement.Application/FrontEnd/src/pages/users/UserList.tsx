import React, { useState } from "react";
import {
    Datagrid,
    Title,
    TextField,
    EditButton,
    FunctionField,
    useRefresh,
    ListBase,
    FilterForm,
    CreateButton,
    SearchInput
} from "react-admin";
import { ButtonGroup, Stack } from "@mui/material";
import HighlightOffIcon from "@mui/icons-material/HighlightOff";
import AssetsPagination from "../../components/pagination/AssetsPagination";
import StateFilterSelect from "../../components/select/StateFilterSelect";
import DetailModal from '../../components/modal/userDetailModal/DetailModal';
import { CustomDeleteWithConfirmButton } from "../../components/modal/confirmDeleteModal/CustomDeleteWithConfirm";
import { assetProvider } from '../../providers/assetProvider/assetProvider'

export default () => {
    const [openDetail, setOpenDetail] = useState({ status: false, data: {} });
    const refresh = useRefresh();

    const usersFilter = [
        <StateFilterSelect
            source="type"
            label="Type"
            sx={{ width:"140px" }}
            statesList={[
                { value: 0, text: "Admin" },
                { value: 1, text: "Staff" },
            ]}
            alwaysOn
        />,
        <SearchInput 
            sx={{ marginRight:"-300px" }}
            InputLabelProps={{ shrink: false }} 
            source="searchString" 
            alwaysOn 
        />
    ];

    return (
        <>
            <Title title="Manage User" />
            <ListBase
                perPage={5}
                sort={{ field: "staffCode", order: "DESC" }}
            >
                <h2 style={{ color: "#cf2338" }}>User List</h2>
                <Stack direction="row" justifyContent="start" alignContent="center">
                    <div style={{ width:"800px", justifyContent:"space-between" }}>
                        <FilterForm style={{ justifyContent: "space-between" }} filters={usersFilter} />
                    </div>
                    <div style={{ display: "flex", alignItems: "end" }}>
                        <CreateButton
                            size="large"
                            variant="contained"
                            color="secondary"
                            label="Create new user"
                            sx={{
                                width: "250px",
                            }}
                        />
                    </div>
                </Stack>

                <Datagrid
                    rowClick={(id, resource, record) => {
                        assetProvider.getOne('user', { id:record.staffCode }).then(res => {
                            setOpenDetail({ status:true, data:res.data })
                        })
                        return "";
                    }}
                    empty={<h2>No User found</h2>}
                    bulkActionButtons={false}
                >
                    <TextField label="Staff Code" source="staffCode" />
                    <TextField label="Full Name" source="fullName" />
                    <TextField label="Username" source="userName" />
                    <FunctionField label="Joined Date" source="joinedDate" render={ data => data.joinedDate.split('T')[0] } />
                    <FunctionField source="Type" render={ data => data.type == "Admin" ? "Admin" : "Staff"} />

                    {/* Button (Edit, Delete) */}
                    <ButtonGroup sx={{ border: null }}>
                        <EditButton variant="text" size="small" label="" />
                        <FunctionField source="userName" render={data =>
                            data.userName != localStorage.getItem("userName") ? <CustomDeleteWithConfirmButton
                            icon={<HighlightOffIcon />}
                            confirmTitle="Are you sure, bro?"
                            confirmContent="Do you want to disable this user, bro?"
                            mutationOptions={{ onSuccess: (data) => refresh() }}
                            /> : <></>
                        } />
                    </ButtonGroup>

                </Datagrid>
                <AssetsPagination />
            </ListBase>
            
            <DetailModal 
                openDetail={openDetail} 
                setOpenDetail={setOpenDetail} 
                label="Detailed User Information"
            />
        </>
    );
};