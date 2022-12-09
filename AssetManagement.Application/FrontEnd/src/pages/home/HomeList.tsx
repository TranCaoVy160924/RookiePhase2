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
import { listStyle } from "../../styles/listStyle";
import AssignmentShow from "../assignments/AssignmentShow";

export default () => {
    const [isOpened, setIsOpened] = useState(false);
    const [record, setRecord] = useState();
    const [assignment, setAssignment] = useState();
    const [deleting, setDeleting] = useState(false);

    useEffect(() => {
        window.addEventListener("beforeunload", () => localStorage.removeItem("item"));
        window.addEventListener("click", () => localStorage.removeItem("item"));
    }, [])

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

    return (
        <Container component="main" sx={{ padding: "20px 10px" }}>
            <Title title="Manage Assignment" />
            <ListBase
                perPage={5}
                sort={{ field: "noNumber", order: "ASC" }}
                filterDefaultValues={{ states: [0, 1] }}
            >
                <h2 style={{ color: "#cf2338" }}>My Assignment</h2>

                <Datagrid
                    rowClick={!deleting ? postRowClick : (id, resource) => ""}
                    empty={
                        <p>
                            <h2>No Data found</h2>
                        </p>
                    }
                    bulkActionButtons={false}
                >
                    <TextField label="Asset Code" source="assetCode" />
                    <TextField label="Asset Name" source="assetName" />
                    <TextField label="Category" source="categoryName" />
                    <DateField label="Assigned Date" source="assignedDate" locales="en-GB" />
                    <FunctionField source="state" render={(record) => {
                        switch (record.state) {
                            case 0: {
                                return "Accepted";
                            }
                            case 1: {
                                return "Waiting For Acceptance";
                            }
                            case 2: {
                                return "Returned";
                            }
                            case 3: {
                                return "Waiting For Returning";
                            }
                        }
                    }} />
                    <ButtonGroup sx={{ border: null }}>
                        <FunctionField render={(record) => {
                            if (record.state === 1) {
                                return (
                                    <ButtonGroup>
                                        <EditButton variant="text" size="small" label="" sx={listStyle.buttonToolbar} />
                                        <CustomDeleteWithConfirmButton
                                            icon={<HighlightOffIcon />}
                                            confirmTitle="Are you sure?"
                                            confirmContent="Do you want to delete this asset?"
                                            mutationOptions={{ onSuccess: () => refresh() }} isOpen={deleting} setDeleting={setDeleting} />
                                    </ButtonGroup>

                                )
                            }
                            else {
                                return (
                                    <ButtonGroup>
                                        <EditButton disabled variant="text" size="small" label=""
                                            sx={listStyle.buttonToolbar} />
                                        <DeleteButton icon={<HighlightOffIcon />} disabled variant="text" size="small" label=""
                                            sx={listStyle.buttonToolbar} />
                                    </ButtonGroup>
                                )
                            }
                        }} />

                        <Button variant="text" size="small"
                            sx={listStyle.returningButtonToolbar}>
                            <ReplayIcon />
                        </Button>
                    </ButtonGroup>
                </Datagrid>
                <AssetsPagination />
                <AssignmentShow isOpened={isOpened} toggle={toggle} assignment={assignment} />
            </ListBase>
        </Container>
    )
};