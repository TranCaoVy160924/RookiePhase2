import React, { useState, useEffect } from "react";
import {
    Datagrid,
    List,
    Title,
    TextField,
    TextInput,
    DateField,
    EditButton,
    useDataProvider,
    FunctionField,
    useRefresh,
    ListBase,
    FilterForm,
    CreateButton,
    Button,
    SearchInput,
    useRecordContext,
    DeleteButton
} from "react-admin";
import { CustomDeleteWithConfirmButton } from "../../components/modal/confirmDeleteModal/CustomDeleteWithConfirm";
import HighlightOffIcon from "@mui/icons-material/HighlightOff";
import ReplayIcon from '@mui/icons-material/Replay';
import AssetsPagination from "../../components/pagination/AssetsPagination";
import StateFilterSelect from "../../components/select/StateFilterSelect";
import { ButtonGroup, Stack, Container, Typography } from "@mui/material";
import { DateAssignedFilterSelect } from "../../components/select/DateAssignedFilterSelect";
import { useNavigate } from "react-router-dom";
import { assetProvider } from "../../providers/assetProvider/assetProvider";
import AssignmentShow from "./AssignmentShow";
import { listStyle } from "../../styles/listStyle";

export default () => {
    const [isOpened, setIsOpened] = useState(false);
    const [record, setRecord] = useState();
    const [assignment, setAssignment] = useState();
    const [deleting, setDeleting] = useState(false);

    const toggle = () => {
        setIsOpened(!isOpened);
    };
    const postRowClick = (id, resource) => {
        assetProvider.getOne("assignments", { id: id })
            .then(response => {
                setAssignment(response.data);
            })
            .catch(err => {
                console.log(err);
            })
        toggle();
        return "";
    };

    const refresh = useRefresh();

    const assignmentsFilter = [
        <StateFilterSelect
            source="states"
            label="State"
            sx={{ width: "250px" }}
            statesList={[
                { value: 0, text: "Accepted" },
                { value: 1, text: "Waiting for acceptance" },
            ]}
            defaultSelect={[0, 1]}
            alwaysOn
        />,
        <DateAssignedFilterSelect source="assignedDateFilter" alwaysOn id="DateAssignedFilterAssignment" />,
        <SearchInput InputLabelProps={{ shrink: false }} source="searchString" alwaysOn />
    ];

    return (
        <Container component="main" sx={{ padding: "20px 10px" }}>
            <Title title="Manage Assignment" />
            <ListBase
                perPage={5}
                sort={{ field: "noNumber", order: "ASC" }}
                filterDefaultValues={{ states: [0, 1] }}
            >
                <h2 style={{ color: "#cf2338" }}>Assignment List</h2>
                <Stack direction="row" justifyContent="end" alignContent="center">
                    <Typography
                        sx={{
                            flexGrow: 1,
                            "form": {
                                "div:nth-of-type(2)": {
                                    marginRight: "auto"
                                }
                            }
                        }}><FilterForm filters={assignmentsFilter} /></Typography>
                    <div style={{ display: "flex", alignItems: "end" }}>
                        <CreateButton
                            size="large"
                            variant="contained"
                            color="secondary"
                            label="Create new assignment"
                            id="createNewAssignmentBtn"
                            icon={<></>}
                        />
                    </div>
                </Stack>

                <Datagrid
                    rowClick={!deleting ? postRowClick : (id, resource) => ""}
                    empty={
                        <p>
                            <h2>No Data found</h2>
                        </p>
                    }
                    bulkActionButtons={false}
                >
                    <TextField label="No" source="noNumber" />
                    <TextField label="Asset Code" source="assetCode" />
                    <TextField label="Asset Name" source="assetName" />
                    <TextField label="Assigned to" source="assignedTo" />
                    <TextField label="Assigned by" source="assignedBy" />
                    <DateField label="Assigned Date" source="assignedDate" locales="en-GB" />
                    <FunctionField source="state" render={(record) => record.state == "0" ? "Accepted" : "Waiting for acceptance"} />
                    <ButtonGroup sx={{ border: null }}>
                        <FunctionField render={(record) => {
                            if (record.state === 1) {
                                return (
                                    <ButtonGroup>
                                        <EditButton variant="text" size="small" label="" sx={listStyle.buttonToolbar}/>
                                        <CustomDeleteWithConfirmButton
                                            icon={<HighlightOffIcon />}
                                            confirmTitle="Are you sure?"
                                            confirmContent="Do you want to delete this asset?"
                                            mutationOptions={{ onSuccess: () => refresh() }} isOpen={deleting} setDeleting={setDeleting}/>
                                    </ButtonGroup>
                                    
                                )
                            }
                            else {
                                return (
                                    <ButtonGroup>
                                        <EditButton disabled variant="text" size="small" label="" 
                                        sx={listStyle.buttonToolbar}/>
                                        <DeleteButton icon={<HighlightOffIcon />} disabled variant="text" size="small" label="" 
                                        sx={listStyle.buttonToolbar}/>
                                    </ButtonGroup>
                                )
                            }
                        }} />
                        
                        <Button variant="text" size="small" 
                        sx={listStyle.returningButtonToolbar}>
                            <ReplayIcon/>
                        </Button>
                    </ButtonGroup>
                </Datagrid>
                <AssetsPagination />
            </ListBase>

            <AssignmentShow isOpened={isOpened} toggle={toggle} assignment={assignment} />
        </Container>
    );
};