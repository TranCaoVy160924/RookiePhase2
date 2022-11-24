import axios from "axios";
import { stringify } from "query-string";
import { CreateParams, CreateResult, DataProvider, DeleteManyParams, DeleteManyResult, DeleteParams, DeleteResult, GetManyParams, GetManyReferenceParams, GetManyReferenceResult, GetManyResult, GetOneParams, GetOneResult, RaRecord, UpdateManyParams, UpdateManyResult, UpdateParams, UpdateResult, fetchUtils } from "ra-core";
import axiosInstance from "../../connectionConfigs/axiosInstance";
import config from "../../connectionConfigs/config.json";

export const assetProvider: DataProvider = {
    getList: (resource, params) => {
        console.log(params);
        const { page, perPage } = params.pagination;
        const { states, searchString } = params.filter;
        const { field, order } = params.sort;
        console.log(states);
        let tmp = "";
        for (const key in states) {
            if (Object.prototype.hasOwnProperty.call(states, key)) {
                const element = states[key];
                tmp += element + "&";
            }
        }
        const query = {
            end: JSON.stringify((page) * perPage),
            start: JSON.stringify((page - 1) * perPage),
            sort: field,
            order: order,
            stateFilter: tmp ? tmp : null,
            searchString: searchString
        };
        const url = `${config.api.base}/api/${resource}?${stringify(query)}`;
        return axios(url).then(res => {
            return Promise.resolve({ data: res.data.assets, total: res.data.total });
        });
    },
    getOne: function <RecordType extends RaRecord = any>(resource: string, params: GetOneParams<any>): Promise<GetOneResult<RecordType>> {
        throw new Error("Function not implemented.");
    },
    getMany: function <RecordType extends RaRecord = any>(resource: string, params: GetManyParams): Promise<GetManyResult<RecordType>> {
        throw new Error("Function not implemented.");
    },
    getManyReference: function <RecordType extends RaRecord = any>(resource: string, params: GetManyReferenceParams): Promise<GetManyReferenceResult<RecordType>> {
        throw new Error("Function not implemented.");
    },
    update: (resource, params) =>
      fetchUtils.fetchJson(`${config.api.base}/api/${resource}/${params.id}`, {
         method: 'PUT',
         body: JSON.stringify(params.data),
      }).then(({ json }) => ({ data: json })),
    updateMany: function <RecordType extends RaRecord = any>(resource: string, params: UpdateManyParams<any>): Promise<UpdateManyResult<RecordType>> {
        throw new Error("Function not implemented.");
    },
    create: function <RecordType extends RaRecord = any>(resource: string, params: CreateParams<any>): Promise<CreateResult<RecordType>> {
        throw new Error("Function not implemented.");
    },
    delete: async (resource, params) => {
        const url = `${config.api.base}/api/${resource}/${params.id}`;
        console.log(url);
        var response = await axiosInstance.delete(url);
        console.log(response.data);
        return response.data;
    },
    deleteMany: function <RecordType extends RaRecord = any>(resource: string, params: DeleteManyParams<RecordType>): Promise<DeleteManyResult<RecordType>> {
        throw new Error("Function not implemented.");
    },
};